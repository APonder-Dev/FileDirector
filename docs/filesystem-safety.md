# Filesystem Safety Model

Filesystem safety is FileDirector's primary product requirement — reliability and safety are
prioritized over feature breadth, especially before `v1.0.0`.

> **Status:** this document describes the target safety model. The mechanisms below are
> implemented starting in Phase 4 (Operation Planner) and Phase 5 (Safe Execution) — see
> [ROADMAP.md](../ROADMAP.md).

## Core guarantees

1. **Planning is pure — no I/O.** Scanning a directory and evaluating rules against it
   produces an immutable `OperationBatch` of `PlannedFileOperation`s. No file is moved,
   copied, renamed, or deleted while a plan is being built.
2. **The user reviews the plan before anything executes.** Every planned operation carries
   its source path, destination path, operation type, matching rule, reason, conflict state,
   reversibility state, required confirmation level, and validation result.
3. **Destructive operations require confirmation.** Anything not trivially reversible
   (deletions, overwrites, operations flagged high-impact) requires explicit approval.
4. **Nothing is permanently deleted by default.** "Delete" actions move files to a managed
   application trash, not to the OS trash and not to `rm`/`Remove-Item`. Permanent deletion is
   a separate, explicit, non-default action.
5. **Every executed batch is journaled.** An operation journal records what was planned, what
   was executed, and the resulting `RollbackRecord`s, enabling undo and partial-failure
   recovery.
6. **Protected paths are never modified by default.** Common OS-critical directories on
   Windows, Linux, and macOS are excluded from scanning and execution unless the user
   explicitly enables an advanced override.

## Collision and conflict handling

- Destination collisions are detected during planning, not discovered mid-execution.
- Configurable automatic conflict-resolution strategies (e.g., counter suffixes) are applied
  only when configured; otherwise conflicts are flagged for manual review rather than
  silently overwritten.
- Case-sensitive vs. case-insensitive filesystem behavior is accounted for so a plan built on
  one platform doesn't silently misbehave on another.

## Reliability under failure

- **Cancellation**: in-flight batches can be cancelled; completed operations remain
  journaled, unstarted ones are simply not executed.
- **Partial failure**: if an operation mid-batch fails (locked file, permission error,
  network-drive drop), already-completed operations in that batch are not rolled back
  automatically — they remain journaled and rollback-capable individually.
- **Locked / read-only files**: detected and reported rather than forced.
- **Cross-volume moves**: handled as copy-then-delete-original with integrity verification,
  since a plain rename/move syscall can't cross volumes.
- **Symbolic links**: never silently followed and modified outside the managed directory;
  link targets outside managed scope are flagged, not traversed.
- **Path traversal**: destination paths are validated to stay within the intended managed
  directory or explicitly configured destination — rule-driven renames/templates cannot
  escape via `../` or similar.

## Duplicate detection is never destructive

Duplicate detection only *identifies* groups of identical files (staged by size → partial
hash → full SHA-256). Nothing is deleted automatically; the user reviews each group, picks a
preferred copy, and duplicates go to managed trash — never straight to permanent deletion.

## Rollback

Every executed operation that has a `RollbackRecord` can be undone: moves/renames restore the
original path, copies remove the copy (not the original), and trashed files are restored from
managed trash. Operations explicitly marked irreversible (e.g., a user-confirmed permanent
delete) are excluded from rollback and clearly labeled as such in history.

## Non-goals

FileDirector does not attempt to protect against a user explicitly and repeatedly overriding
its safeguards (e.g., enabling the protected-directory override and confirming a permanent
delete). The safety model prevents *accidental* data loss, not intentional destructive action
taken with full confirmation.

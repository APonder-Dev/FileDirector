# Rule Engine

> **Status:** design reference for Phase 3. Not yet implemented — see [ROADMAP.md](../ROADMAP.md).

The rule engine evaluates composable conditions against file metadata and produces actions,
deterministically: given the same file metadata and rule configuration, evaluation always
produces the same plan.

## Conditions

File extension, MIME type, exact filename, filename contains, filename wildcard, regular
expression, file size, creation date, modification date, file age, source directory,
duplicate status, file hash, image dimensions (when metadata is available), hidden-file
status, read-only status.

## Actions

Move, copy, rename, add prefix, add suffix, create destination directory, archive, move to
managed trash, skip, flag for manual review.

## Composition

- Conditions combine with AND / OR logic and support nested condition groups.
- Rules have priority ordering, enabled/disabled state, and optional stop-processing
  behavior (a matched rule can prevent lower-priority rules from also matching the same
  file).
- Rules are versioned; edits create a new version rather than silently mutating history.
- Every evaluation result includes a human-readable explanation of why a rule did or did not
  match.

## Rename templates

Supported tokens: `{original-name}`, `{extension}`, `{year}`, `{month}`, `{day}`, `{counter}`,
`{size}`, `{hash-short}`.

```
{year}-{month}-{day}_{original-name}_{counter}.{extension}
```

Templates are validated before use: invalid characters are sanitized, collisions are
detected (via `{counter}` or flagged for manual review), case sensitivity and cross-platform
filename restrictions are enforced, and maximum path length is checked — all before any
rename is planned, let alone executed.

## Determinism

Given identical input (file metadata snapshot + rule set + rule order), the planner always
produces the identical `OperationBatch`. This is what makes dry-run preview trustworthy: what
you approve is what executes.

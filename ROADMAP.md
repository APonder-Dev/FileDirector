# Roadmap

FileDirector is developed in incremental phases. Advanced features are not started until the
initial vertical slice works end-to-end with automated tests:

> Register Directory → Define Extension Rule → Scan Directory → Generate Preview →
> Approve Plan → Move File → Record Operation → Roll Back Operation

## Phases

- [x] **Phase 1 — Repository Foundation**: solution structure, shared build config, package
      management, logging foundation, test projects, GitHub workflows, documentation skeleton.
- [ ] **Phase 2 — Domain Model**: core entities, value objects, domain validation, operation
      states, rule states.
- [ ] **Phase 3 — Rule Engine**: condition/action contracts, rule evaluation, condition groups,
      rule validation, tests.
- [ ] **Phase 4 — Operation Planner**: file discovery, metadata collection, planned operations,
      conflict detection, preview output.
- [ ] **Phase 5 — Safe Execution**: move/copy/rename, managed trash, operation journal,
      cancellation, error recovery.
- [ ] **Phase 6 — Persistence**: SQLite, EF Core, migrations, history, settings, duplicate
      records.
- [ ] **Phase 7 — CLI**: scan, preview, apply, history, rollback, rules commands.
- [ ] **Phase 8 — Desktop Application**: MVVM foundation, dashboard, directory management,
      rule editor, preview, history.
- [ ] **Phase 9 — Duplicate Detection**: size grouping, partial hashes, complete hashes,
      duplicate review.
- [ ] **Phase 10 — Monitoring**: directory watcher, debouncing, stable-file checks, monitoring
      status.
- [ ] **Phase 11 — Hardening**: protected paths, symlink handling, path traversal protection,
      cross-platform testing, failure recovery.
- [ ] **Phase 12 — Release Preparation**: packaging, release workflow, checksums,
      documentation, screenshots.

## Versioning

FileDirector will not be tagged `v1.0.0` until the core safety model, rollback behavior, and
test suite are stable across all supported platforms. Pre-1.0 releases use `0.x.y`.

## Next up

Phase 2 — Domain Model: `ManagedDirectory`, `FileRule`, `RuleCondition`/`RuleConditionGroup`,
`RuleAction`, `PlannedFileOperation`, `OperationBatch`, `OperationResult`, `RollbackRecord`,
`DuplicateGroup`, and related value objects, with domain unit tests for validation and state
transitions.

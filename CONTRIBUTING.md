# Contributing

Thanks for your interest in FileDirector. This document covers the development workflow,
branch/commit conventions, and expectations for pull requests.

## Getting started

```bash
git clone https://github.com/APonder-Dev/FileDirector.git
cd FileDirector
dotnet restore
dotnet build
dotnet test
```

Requires the [.NET 9 SDK](https://dotnet.microsoft.com/download) or later.

## Branching

Branch off `main` using a descriptive, prefixed name:

```
feature/rule-engine
feature/operation-planner
fix/path-collision-handling
docs/filesystem-safety
test/rollback-recovery
```

Do not commit directly to `main`.

## Commits

Use [Conventional Commits](https://www.conventionalcommits.org/):

```
feat: add rule evaluation engine
fix: prevent destination path collisions
test: add rollback recovery coverage
docs: document filesystem safety model
ci: add cross-platform build workflow
```

## Before every commit

```bash
git status
git diff
dotnet format --verify-no-changes
dotnet build
dotnet test
```

Fix anything that fails before committing. Do not force-push shared branches unless
explicitly asked to.

## Pull requests

- Fill out the PR template, including the filesystem-safety checklist when your change
  touches scanning, rule evaluation, planning, or execution.
- Add or update tests for behavior changes. Tests must use isolated temporary directories —
  never modify the real user profile or repository files during a test run.
- Update relevant documentation (`README.md`, `ARCHITECTURE.md`, `docs/`, ADRs) alongside
  the code change, not as a follow-up.
- Keep PRs scoped to one concern where practical.

## Code style

Enforced via `.editorconfig` and `dotnet format`; nullable reference types are enabled
solution-wide, and warnings are treated as errors in Release builds. Don't place business
logic in Desktop views/code-behind — it belongs in the Application layer, invoked from view
models.

## Filesystem safety expectations

Any change touching scanning, planning, or execution must preserve these invariants
(see [docs/filesystem-safety.md](docs/filesystem-safety.md) for the full model):

- Planning never performs I/O
- Destructive operations require confirmation and route through managed trash, not permanent
  deletion
- Protected OS directories remain protected unless the user has explicitly enabled the
  advanced override
- Every executed batch remains rollback-capable unless explicitly marked irreversible with a
  documented reason

## Attribution

All contributions are attributed to their human author. Do not add AI-generated-content
notices, AI co-author trailers, or similar automation attribution to commits, code comments,
or documentation.

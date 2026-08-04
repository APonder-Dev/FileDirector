# Configuration

> **Status:** design reference. Import/export and validation land alongside the rule engine
> (Phase 3) and application services (Phase 4+) — see [ROADMAP.md](../ROADMAP.md).

FileDirector rule sets and application settings can be authored as JSON or YAML and are
validated (via FluentValidation) before any scan or execution runs against them. Validation
failures are reported as specific, actionable errors — not a generic parse failure.

## Planned example configurations

Example configurations will live under `docs/examples/` and `samples/`, covering:

- Downloads folder organization
- Images organized by year and month
- Documents organized by category
- Archives based on file age
- Duplicate detection
- Development-project cleanup
- Screenshot organization
- Log-file archival

## Import / export

Configuration (managed directories, rules, settings) can be exported to a portable file and
re-imported elsewhere — validated on import the same way as on first load, so an invalid or
tampered file is rejected with clear errors rather than partially applied.

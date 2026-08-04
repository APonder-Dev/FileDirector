# 1. Clean architecture layering with Domain having zero external dependencies

Date: 2026-08-04

## Status

Accepted

## Context

FileDirector plans and executes real filesystem operations driven by user-configurable
rules. The rule engine and operation planner need to be testable without touching disk, and
dry-run preview needs to be trustworthy (what's previewed must be exactly what executes).

## Decision

Use a modular clean architecture: `FileDirector.Domain` (entities, value objects, domain
rules) has no dependency on infrastructure, UI, database, or OS APIs.
`FileDirector.Application` (services, rule engine, planner) depends only on Domain and
defines the interfaces Infrastructure implements. `FileDirector.Infrastructure` (EF Core/
SQLite, filesystem, Serilog, monitoring) implements those interfaces. `FileDirector.Desktop`
and `FileDirector.Cli` are both thin presentation layers over Application services.
`FileDirector.PluginSdk` depends only on Domain, keeping future extension contracts free of
infrastructure concerns.

## Consequences

- The rule engine and planner can be unit tested with in-memory data, no filesystem or
  database required.
- Planning is enforced to be side-effect-free by construction: Application has no
  filesystem access to reach for, even by accident — only Infrastructure does.
- Adds a small amount of ceremony (interfaces in Application, implementations in
  Infrastructure) that a script wouldn't need — accepted deliberately, since FileDirector is
  explicitly not "a simple script that sorts files by extension."

# Plugin Development

> **Status:** contracts only, no plugin loading yet. See [ROADMAP.md](../ROADMAP.md).

`FileDirector.PluginSdk` will define a minimal, versioned extension contract for custom rule
conditions and actions. Deliberately, **arbitrary plugin loading is not implemented until the
core engine is stable** — the contracts and their security boundaries are defined and
documented first.

## Why the delay

A plugin system that loads arbitrary third-party code into a process that has filesystem
write access is a meaningful security surface. Rushing plugin loading ahead of a stable,
well-tested core rule engine and operation planner would make it harder to reason about what
FileDirector can do to a user's files. The SDK contracts are versioned from day one so real
plugin loading can be added later without breaking early adopters, but loading is out of
scope until then.

## Intended security boundaries (for when loading is implemented)

- Plugins implement condition/action contracts; they do not get direct, unmediated
  filesystem access — they operate on the same `PlannedFileOperation`/metadata objects the
  built-in engine uses, and the Infrastructure layer remains the sole executor.
- Plugin assemblies will require explicit user opt-in per plugin, not automatic discovery
  and execution of anything found in a directory.
- Plugin API versioning will follow semantic versioning so breaking contract changes are
  never silently loaded against an incompatible plugin.

This document will be expanded with the concrete contract shapes once Phase 3 (Rule Engine)
defines the condition/action interfaces the SDK extends.

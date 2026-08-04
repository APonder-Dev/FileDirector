# 2. Central package management via Directory.Packages.props

Date: 2026-08-04

## Status

Accepted

## Context

FileDirector spans six `src/` projects and four `tests/` projects. Without a single source of
truth for package versions, the same package (e.g., `xunit`, `Microsoft.EntityFrameworkCore.Sqlite`)
tends to drift to different versions across projects over time, which is hard to notice and
harder to reason about during dependency upgrades or security patching.

## Decision

Enable NuGet Central Package Management: `Directory.Packages.props` at the repository root
declares every package version once; individual `.csproj` files reference packages by name
only (`<PackageReference Include="Serilog" />`, no `Version` attribute).
`CentralPackageTransitivePinningEnabled` is also enabled so transitive dependency versions are
pinned deterministically.

## Consequences

- One place to bump a version; Dependabot's `groups` config in `.github/dependabot.yml`
  targets this file directly.
- A `.csproj` that includes a `Version` attribute on a `PackageReference` will fail to build,
  which is intentional — it surfaces accidental version drift immediately instead of letting
  it silently diverge.

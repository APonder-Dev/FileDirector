# Release Process

FileDirector uses [Semantic Versioning](https://semver.org/). `v1.0.0` is not tagged until
the core safety model (dry-run, managed trash, protected paths), rollback behavior, and the
automated test suite are stable across Windows, Linux, and macOS.

## Cutting a release

1. Ensure `main` is green: `dotnet format --verify-no-changes`, `dotnet build`, `dotnet test`
   all pass in CI.
2. Update `CHANGELOG.md` — move `[Unreleased]` entries under a new version heading.
3. Tag the release: `git tag vX.Y.Z && git push origin vX.Y.Z`.
4. The `release.yml` GitHub Actions workflow builds and publishes self-contained CLI and
   Desktop binaries for `win-x64`, `linux-x64`, `osx-x64`, and `osx-arm64`, each as a zip with
   a `.sha256` checksum file, and opens a **draft** GitHub Release with the artifacts
   attached.
5. Review the draft release notes, verify checksums, and publish manually — releases are
   never auto-published without human review.

## Versioning rules

- **Major**: breaking changes to rule configuration format, CLI command surface, or plugin
  contract.
- **Minor**: new features (new conditions/actions, new CLI commands, new UI pages) that are
  backward compatible.
- **Patch**: bug fixes, documentation, non-breaking internal changes.

## Supported platforms

Windows, Linux, and macOS (x64 and Apple Silicon), each with a portable, self-contained
distribution — no separate .NET runtime install required.

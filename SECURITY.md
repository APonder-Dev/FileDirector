# Security Policy

## Reporting a vulnerability

If you find a security issue in FileDirector — including anything that could cause
unintended data loss, unauthorized file access, or a path-traversal/escape from a managed
directory — please report it privately rather than opening a public issue.

Use GitHub's [private vulnerability reporting](https://github.com/APonder-Dev/FileDirector/security/advisories/new)
for this repository. Include:

- A description of the issue and its impact
- Steps to reproduce (rule configuration, directory layout, commands run)
- Affected version/commit

Please do not include real personal file paths or data in reports — synthetic
reproduction data is sufficient and preferred.

## Scope

FileDirector reads, moves, copies, renames, and archives files based on user-defined rules.
Security-relevant areas include:

- Path validation and traversal protection
- Protected operating-system directory safeguards
- Managed trash and rollback integrity
- Symbolic link handling
- Rule/plugin extension boundaries (see [docs/plugin-development.md](docs/plugin-development.md))
- Configuration import/export (untrusted YAML/JSON input)

## Filesystem safety model

FileDirector's core safety guarantees are documented in
[docs/filesystem-safety.md](docs/filesystem-safety.md). Notably:

- No filesystem changes occur during planning — only after explicit user approval
- Deletions go to managed trash by default; nothing is permanently deleted automatically
- Protected OS directories are never modified unless an advanced override is explicitly enabled
- Every executed operation batch has a rollback record

## Supported versions

Until a 1.0 release, only the latest commit on `main` is supported with security fixes.
Versioning and support windows will be documented here as releases are cut — see
[docs/release-process.md](docs/release-process.md).

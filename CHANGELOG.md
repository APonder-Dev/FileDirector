# Changelog

All notable changes to this project are documented in this file. Format follows
[Keep a Changelog](https://keepachangelog.com/en/1.1.0/); versioning follows
[Semantic Versioning](https://semver.org/).

## [Unreleased]

### Added

- Repository foundation: solution structure (`FileDirector.Domain`, `FileDirector.Application`,
  `FileDirector.Infrastructure`, `FileDirector.Desktop`, `FileDirector.Cli`,
  `FileDirector.PluginSdk`) and matching test projects.
- Centralized build configuration (`Directory.Build.props`, `Directory.Packages.props`),
  `.editorconfig`, `.gitattributes`, `.gitignore`.
- Serilog-based logging foundation and cross-platform application-data path resolution
  (`ApplicationPaths`, `LoggerBootstrapper`) in the Infrastructure layer.
- GitHub Actions workflows for CI (build/test/format across Windows/Linux/macOS), security
  scanning (NuGet vulnerability audit + CodeQL), and release packaging.
- Issue templates, PR template, CODEOWNERS, and Dependabot configuration.
- Documentation skeleton (README, ARCHITECTURE, SECURITY, CONTRIBUTING, ROADMAP, docs/, ADRs).

No functional file-organization behavior exists yet — this is the foundation phase only.

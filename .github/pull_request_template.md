## Summary

<!-- What does this change do, and why? -->

## Related issue

<!-- Closes #... -->

## Type of change

- [ ] Feature
- [ ] Fix
- [ ] Refactor / tech debt
- [ ] Documentation
- [ ] Tests
- [ ] CI / build

## Filesystem safety checklist

If this change touches scanning, rule evaluation, planning, or execution:

- [ ] No filesystem changes occur during planning (plans remain preview-only)
- [ ] Destructive operations still require confirmation / go through managed trash
- [ ] New behavior has dry-run coverage
- [ ] Rollback/undo still works for affected operation types

## Testing

<!-- Commands run, e.g. dotnet format --verify-no-changes / dotnet build / dotnet test -->

- [ ] `dotnet format --verify-no-changes`
- [ ] `dotnet build`
- [ ] `dotnet test`

## Checklist

- [ ] Tests added or updated for the change
- [ ] Documentation updated (README/ARCHITECTURE/docs/adr as applicable)
- [ ] No secrets, credentials, or real user paths committed

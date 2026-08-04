# Duplicate Detection

> **Status:** design reference for Phase 9. Not yet implemented — see [ROADMAP.md](../ROADMAP.md).

Duplicate detection runs in stages, cheapest checks first, so large libraries don't require
hashing every file up front:

1. **Group by size.** Files with a unique size in the managed set can't be duplicates of
   anything and are skipped immediately.
2. **Partial hash.** For same-size groups, hash a prefix of each file — enough to rule out
   most false positives cheaply.
3. **Full SHA-256 hash.** Only for files that survive stage 2 — the full-content hash confirms
   true duplicates.
4. **Confirm.** A `DuplicateGroup` is finalized only when size and full hash both match.

## Review, never auto-delete

- Users review each duplicate group and select the preferred copy.
- Non-preferred copies move to managed trash — never straight to permanent deletion.
- Specific files or entire directories can be excluded from future duplicate scans.
- Duplicate reports can be exported for review outside the app.
- Groups can be re-scanned, and prior user decisions (which copy was preferred, what was
  ignored) are preserved across re-scans rather than re-prompting from scratch.

Nothing in this pipeline deletes a file automatically.

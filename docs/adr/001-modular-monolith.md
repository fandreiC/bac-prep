# ADR-001: Modular monolith instead of microservices

- Status: Accepted
- Date: 2026-11-15

## Context
Bac Prep is built by one developer in 6 weeks, for a small number of users at first.
The domain splits into clear areas: Content, Practice, Students and Notifications
(see docs/class-diagram.md). Traffic is low most of the year, with peaks before the Bac in May–June.
Hosting must stay within Azure's free allowances.

## Decision
Build one ASP.NET Core application (BacPrep.Api) made of four module projects:
BacPrep.Modules.Content, .Practice, .Students and .Notifications.

Rules:
- Each module owns its own data. No module reads another module's tables.
- Modules never reference each other. Only BacPrep.Api references the modules.
- Across modules, entities refer to each other by ID only (e.g. Attempt.StudentId).
- Modules communicate through defined interfaces or messages (from week 3).

## Alternatives considered
- **Microservices:** separate deployments, networking, monitoring and data consistency problems.
  Too much infrastructure for one developer and the current load.
- **Classic layered monolith** (one project with Controllers / Services / Repositories):
  simplest to start, but module boundaries blur over time and become hard to separate later.

## Consequences
- Positive: one deployment, simple local development and debugging, low hosting cost.
- Positive: a module can later become a separate service, because its boundaries already exist.
- Negative: boundaries rely on discipline. Mitigation: no project references between modules,
  and architecture tests (week 2) that fail the build if a module depends on another.
- Negative: all modules scale together. Acceptable for v1; revisit if the Bac peak requires it.
---
name: zamin
description: >-
  Guides coding against the Zamin (.NET) framework using packaged API reference
  and battle-tested usage patterns. Use whenever writing, reviewing, refactoring,
  or wiring code that depends on Zamin—Command/Query handlers, AggregateRoot/
  Entity/ValueObject, BaseController, repositories, AddZaminApiCore / DI
  extensions, ZaminServices, caching, Parrot translator, message bus, outbox,
  Serilog registration, or any Zamin.* namespace. Activate before inventing
  Zamin APIs from memory; prefer references/ over guessing.
---

# Zamin Framework Skill

Use this skill whenever the task involves **writing or changing code that uses the Zamin framework**. Do not rely on remembered Zamin APIs; load the references below.

## Required workflow

1. **Read** [references/overview.md](references/overview.md) first (architecture, core concepts, recommended start path).
2. **Open the matching API file** under [references/api-reference/](references/api-reference/) for the namespace/types you will call (use [references/_toc.md](references/_toc.md) as the map). Multi-part namespaces use `*.PartN.md`.
3. **Before writing Zamin-using code**, check the related files under [references/patterns/](references/patterns/) so you follow **real usage recipes** (composition, DI order, call flow)—not only method signatures:
   - Host / DI / registration → [references/patterns/dependency-injection.md](references/patterns/dependency-injection.md)
   - CQRS, domain, repositories, controllers → [references/patterns/common-recipes.md](references/patterns/common-recipes.md)
4. **If a type appears in** [references/patterns/unused-types.md](references/patterns/unused-types.md): treat it cautiously—there is **no practical usage sample available**. Implement only from `api-reference/` (and mark uncertainty if docs say «مستندات کافی موجود نیست»). Do not invent call patterns.
5. Optional coverage check: [references/raw-extraction/_index.json](references/raw-extraction/_index.json) lists extracted namespaces/types from the Zamin source scan.

## Reference layout

```
references/
  overview.md              # Start here
  _toc.md                  # Full file index + one-line blurbs
  api-reference/           # One (or PartN) markdown file per Zamin namespace
  patterns/
    dependency-injection.md
    common-recipes.md
    unused-types.md
    by-namespace/          # Raw per-namespace notes from application usage (optional detail)
    general-recipes.md     # Earlier consolidated draft (optional)
  raw-extraction/
    _index.json            # Namespace/type coverage inventory
```

## Coding rules (Zamin-specific)

- Prefer patterns proven in application code recipes: thin `BaseController`, `CommandHandler`/`QueryHandler` + `ZaminServices`, `ICommandRepository`/`IQueryRepository`, `AggregateRoot`/`Entity`, `AddZaminApiCore` discovery.
- Match **DI registration order** from dependency-injection recipes when bootstrapping a host.
- Do not fabricate extension method names, option type names, or dispatcher decorator behavior; if missing from references, say so and stop guessing.
- When both a signature (api-reference) and a recipe (patterns) exist, **recipe wins for how to compose**; api-reference wins for exact members/signatures.

## Quick scenario map

| Need | Read next |
|------|-----------|
| New vertical feature (command/query/API) | overview → common-recipes (vertical slices) → api-reference for Commands/Queries/Domain/Infra/EndPoints |
| Host Program / ConfigureServices | dependency-injection → api-reference for Extensions.DependencyInjection / Serilog / Auth options |
| Domain model | common-recipes (aggregate/VO/exceptions) → Domain.* api-reference |
| Type never shown in usage patterns | unused-types → api-reference only |

## Progressive disclosure

Keep SKILL.md as the router. Load only the reference files needed for the current task; do not dump all of `api-reference/` into context at once.

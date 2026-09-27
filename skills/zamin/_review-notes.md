# Zamin skill — review notes (simulation)

Date: 2026-09-27  
Method: Follow `SKILL.md` workflow only; open `references/` files. Do **not** use Zamin source trees as the answer key for this review.

## Setup check

| Item | Status |
|------|--------|
| `skills/zamin/SKILL.md` | Present; auto-trigger description (no `disable-model-invocation`) |
| `references/overview.md` | Present |
| `references/api-reference/` | 136 markdown files |
| `references/patterns/` | DI + common-recipes + unused-types (+ by-namespace / drafts) |
| `references/raw-extraction/_index.json` | Present (97 namespaces / 258 types inventory) |

---

## Scenario A — «یک سرویس/فیچر جدید بر پایه زمین بساز»

**Agent path:** overview → common-recipes (vertical command/query) → api-reference for Commands, Queries, Domain, Infra, EndPoints, Utilities → dependency-injection if host wiring needed.

**Can write correct code without Zamin source?** **Yes, for the happy path.**

Sufficient to produce:

- `record XCommand : ICommand<TData>` / `ICommand`
- `CommandHandler<TCommand,TData>(ZaminServices, …)` with `Handle` → `InsertAsync` → `CommitAsync` → `OkAsync`
- Aggregate inheriting `AggregateRoot` / `AggregateRoot<TId>` + factory pattern (from recipe samples)
- `BaseCommandRepository<…>` / `ICommandRepository` usage
- API controller inheriting `BaseController` with `Create` / `Edit` / `Delete` / `Query`
- Host registration shape: decorator → `AddZaminApiCore("…")` → cache/translator/EF interceptors (from DI recipes)

**Gaps / risks:**

- Exact **NuGet package IDs** and csproj references are not in the skill (only namespaces/types).
- Project **folder/layer conventions** come from application usage samples inside recipes, not a standalone Zamin template.
- Some api-reference members show truncated bodies (`=> ...`); enough for signatures, not for re-implementing framework internals.
- HTTP status mapping from `CommandResult` / `ApplicationServiceStatus` to `IActionResult` is implied via `BaseController` helpers, not fully spelled out as a table.

**Verdict:** Enough for an agent to scaffold a typical vertical slice correctly if it follows recipes.

---

## Scenario B — «هاست جدید را با DI زمین بالا بیاور»

**Agent path:** dependency-injection.md → api-reference `Zamin.Extensions.DependencyInjection*` / Serilog / Auth options / cache options.

**Can write correct code?** **Mostly yes for API host; partial for Worker messaging.**

Sufficient:

- `SerilogExtensions.RunWithSerilogExceptionHandling` + `AddZaminSerilog` options pattern
- `AddZaminApiCore`, Parrot, serializer, AutoMapper, Redis/SQL cache switch, `AddZaminApiAuthentication` / Swagger
- EF interceptors `SetPersianYeKeInterceptor`, `AddAuditDataInterceptor`
- Pipeline: `UseZaminApiExceptionHandler`

Gaps:

- Worker messaging DAL recipe explicitly notes missing full snippet («مستندات کافی موجود نیست»).
- Commented-out RabbitMQ / PollingPublisher / MessageInbox application registrations in application code → agents must not assume those are “the” production pattern.
- Option class property lists exist in api-reference but end-to-end appsettings JSON schema is incomplete.

**Verdict:** Solid for standard API bootstrap; caution on messaging/outbox advanced wiring.

---

## Scenario C — «از EventDispatcher / IDomainEventStore استفاده کن»

**Agent path:** unused-types.md (listed) → api-reference Events / Contracts only.

**Can write correct code?** **Weak — signatures only, no proven composition.**

- Types appear in `unused-types.md`; skill correctly tells agent to be cautious.
- `BaseController` exposes `EventDispatcher` property, but MyApp has no real usage sample for event dispatch pipeline.
- No recipe for registering event handlers, decorator order, or outbox publish loop beyond DbContext inheritance notes.

**Verdict:** Agent can declare types/signatures but should **not** invent a full event-driven flow; must flag uncertainty.

---

## Scenario D — «Value Object سفارشی + استثنای دامنه»

**Agent path:** common-recipes (VO + exceptions) → Domain.ValueObjects / Toolkits / Exceptions api-reference.

**Can write correct code?** **Yes.**

Sufficient: `BaseValueObject<T>`, toolkit VOs (`Title`, …), `InvalidValueObjectStateException` / `InvalidEntityStateException`, and MyApp-style throw sites in recipes.

Gap: Equality/compare implementation details for custom VOs may need reading multiple api-reference members; still doable without source.

---

## Scenario E — «فقط امضای متد را از api-reference کپی کن، patterns را نخوان»

**Result if skill is ignored:** High risk of wrong composition (e.g. `new`ing handlers, skipping `ZaminServices`, wrong DI order, calling unused decorators manually).

**Result if skill is followed:** Recipes override composition; this is correctly encoded in SKILL.md (“recipe wins for how to compose”).

---

## Cross-cutting gaps (skill pack)

1. **No `enriched/*.json` in the skill** — intentional progressive disclosure; deep member nuance may be thinner than the original enrichment dump. api-reference is usually enough for coding.
2. **Multi-part api files** — agents must open Part1…PartN (TOC/overview help; easy to miss Part2+).
3. **Recipe coupling to sample apps** — patterns are battle-tested, not “official Zamin docs.” Other products may differ; skill should be treated as Zamin via documented recipes.
4. **Package / version matrix** — missing; agents need the consuming project’s PackageReferences.
5. **FluentValidation / IValidator** — mentioned in decorator docs; end-to-end validator registration recipe is thin (`AddNonValidatingValidator` appears in DI narrative).
6. **Persian/English mix** in references — fine for bilingual agents; some headings are Persian-only.

---

## Summary

| Scenario | Enough to code correctly? |
|----------|---------------------------|
| New CQRS feature + API | Yes (with recipes) |
| API host DI bootstrap | Yes (main path) |
| Unused event/store APIs | No solid recipe — caution |
| Custom VO / domain exceptions | Yes |
| Messaging/Worker advanced | Partial |

**Overall:** With SKILL.md + references, an agent can implement typical Zamin-based application code **without opening Zamin source**, provided it follows the required workflow and treats `unused-types.md` as a hard caution list. Remaining gaps are packaging, advanced messaging/events, and a few truncated implementation details—not the core CQRS vertical slice.

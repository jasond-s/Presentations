(**
- title : Architecture and Design
- description : Market invoice architecture and design.
- author : Jason Dryhurst-Smith
- theme : night
- transition : default

***

# Architecture and Design

***

## Solutions

#### Will need to run `go.bat`

- Platform (too big we know)
- Database Migration (MiCoreDb2)
- Identity Server
- Company Information Service
    - Validis

- Infrastructure (for interesting things)

---

### Structure

- low project count
- use namepsaces
- nuget only via solution

***

## Projects

---

### Language

- prefer C#
- open to use F# where appropriate
- tooling in power shell (invoke-build)

---

### Naming

- Marketinvoice prefix
    - Tests
    - Api
    - Contract

---

### Contracts

- Expose all types external to solution using a `Marketinvoice.XXX.Contracts` project
- Only allow `Newtonsoft.Json` as dependancy to aid any consuming serialisers
- Clients abstracted in consumer not producer
- Versioned via `version.txt`, read by build pipline and updates assembly info.

***

## Testing

---

### Not optional

---

### TDD totally is though...

---

## Typescript/Javascript

### Karma + Jasmine + Protractor

- Cubitt will go over this in detail.

---

## .Net

---

### MSpec

- widely used and there is a lot of infrastructure out there (esspecially in the platform solution) to get up and running quickly.

- `WithFakeDatabase` and `With_SharedDatabase`, both used to get integration tests up and running.

---

### NUnit

- Also widely used and a lot of knowledge in the team.

---

#### Be pragmatic

- Don't re-write tests because you don't like the framework.
- Try to stick with the framework used to test a feature/area/app.
- `EntityFakes` - Useful for test data.
- Phasing out in favour of builders `MarketInvoice.TestingInfrastructure.TestDataBuilders`.

***

## Code

---

### CQS

`MarketInvoice.Infrastructure.CommandQuery`

- we try to apply command and query patterns, it's patchy.

- but we have a mission.

---

### Query

    [lang=cs]
    public interface IQueryWithArgs<in TArgs, out TResult>
    {
        TResult Execute(TArgs args);
    }

    ...

    // DB Querying using Entity Framework uses a specification abstraction.
    public static Specification<Auction> ActiveAuctions()
    {
        return new SimpleSpecification<Auction>(auction => auction.AuctionStateId == (int) AuctionStates.Active);
    }

---

### Command

    [lang=cs]
    public interface ICommand<TArgs>
    {
        ValidationResults Execute(TArgs args);
    }

---

### Validation

    [lang=cs]
    public class ValidationResults
    {

      ...

      public void Add(string memberName, string errorMessage)
      {
          Add(new ValidationResult(errorMessage, new[] { memberName }));
      }

      ...

      public bool Success {
          get {
            return !_validationResults.IsValueCreated ||
                    _validationResults.Value.Count == 0 ||
                    _validationResults.Value.All(v => v == ValidationResult.Success);
          }
      }

---

    [lang=cs]
    public interface IValidator<in T>
    {
        bool StopsValidation { get; }

        ValidationResults Validate(T instance);
    }


---

### EF

- Take a look at this handy guide.

---

### Services

- Used generally as orchestrators.
- Some work being done on whether command and queries should use services or services should orchestrate command and queries. Both patterns are used on the platform.

---

### CIA

- key
- fetch
- merge
- store

---



*)
(**
- title : FUNctional Programming
- description : Introduction to Functional Programming
- author : Jason Dryhurst-Smith
- theme : night
- transition : default

***

# FUNctional Programming

### A short amount of nonsense about what I have found so far.

</br>

#### By Jason age 8 and 240 months.

***

### Shout Outs

#### Generation

**[reveal.js](http://lab.hakim.se/reveal-js/#/)** presentation from [markdown](http://daringfireball.net/projects/markdown/)

#### Formatting

**[FSharp.Formatting](https://github.com/tpetricek/FSharp.Formatting)** for markdown parsing

#### Railway Oriented Design

**[Scott Wlaschin](http://fsharpforfunandprofit.com/)** F# for fun and profit

***

### Ridiculous Biases

#### And attempted corrections

- **Knowledge:** I am a .Net dev (mostly) so deepest knowledge lies here.

- **Platform:** This is why I am using F# and C# in examples.

- **Recency Illusion:** Functional programming is relatively new to me.

***

## What I'm asking you to just accept for the moment

#### F#

- A function is a value.
- A function is a thing.
- A function can be a pattern or interface.
- <del>Lambda calculus.</del>
- <del>Monads and monoids.</del>
- Basically it's all functions.

***

# 1

## Structure

***

### Class Orientation

#### C#

    [lang=cs]
    class SuperDoer : Doing, IDoStuff {
      public override string Doing { get; set; }
      public SuperDoer(string doing){
        this.Doing = doing;
      }
      public bool DoStuff() {
        return true;
      }
    }

    class LameDoer : Doing, IDoStuff {
      public override string Doing { get; set; }
      public LameDoer(string doing){
        this.Doing = doing;
      }
      public bool DoStuff() {
        return false;
      }
    }

    class AmazingDoerChecker {
      public string WhosDoingIt(IDoStuff stuffdoer) {
        return stuffdoer.DoStuff() ? "Pay Rise" : "P45";
      }
    }

    public void Main(object[] args) {
      new AmazingDoerChecker()
          .WhosDoingIt(new LameDoer("I am so lazy"))
    }

---

### What is that?

#### C#

- Polymorphism via inheritance.
- Easy to add new 'kinds' of things.
- Mutable, hardware efficient.
- SOL<del>I</del>D, although contradictions arrise.

---

### What is that not?

#### C#

- Simple to see the structure of all the things.
- Easy to add new behaviour.
- Easily to spec a concurrent model.
- When is an I not an S?

![Umm, guys I'm trying to get through here.](./images/deadlock.jpg)

***

### Functional Orientation

#### F#

*)
type Doing = string
type Doer =
    | Super of Doing
    | Lame of Doing

let whosDoingIt doer =
  match doer with
  | Super _ -> "Pay Rise"
  | Lame _ -> "P45"
  | _ -> "Holiday?"

whosDoingIt (Super "I'm so busy its crazy.")
(**

---

### What is that?

#### F#

- Polymorphism via type composition and 'matching'.
- Easy to add new stuff our things can do.
- Still SOLID.
- Immutable by default, safe and easy to reason about.
- Easy to see the structure of the things.

---

### What is that not?

#### F#

- Things and what they do can be scattered.
- Not very easy to add new things.
- Recursive structure is not warmly received.
- Immutability is **NOT** hardware efficient.

![I swear I have it right this time.](http://imgs.xkcd.com/comics/haskell.png)

***

# 2

## Composability

#### (It's a word, I looked it up.)

- Why?
- How?
- Where??
- When?????

***

#### C#

    [lang=cs]
    class SuperDoer : Doing, IDoStuff {

      private IWorkService _workService;

      public override string Doing { get; set; }

      public SuperDoer(string doing, IWorkService workService){
        this.Doing = doing;
        this._workService = workService;
      }

      public bool DoStuff() {
        return this._workService(this.Doing);
      }
    }

---

#### C#

- Structural composition. We can make pretty much any thing out of pretty much any other thing or set of things.

- This is really cool and declarative. 

- The car abstraction doesn't need to know about how many bolts a wheel needs.

***

#### F#

*)
type Seats = int
type Controls = string
type CarBody = Seats * Controls
type Nuts = int
type Bolts = int
type Wheel = Nuts * Bolts

type WheeledVehicle =
    | Wheel of Wheel list
    | Body of CarBody

type Vehicle =
    | Car of WheeledVehicle
    | Lorry of WheeledVehicle
    | Horse of string        
(**

---

#### F#

- We can do a bit of structural composition here to. But... 

- Also, complex nested or cyclic relationships are _**HARD**_ to represent.

- This is also awesome and declaritive but it does not prevent us from doing awesome things, *ahem* functional composition.

***

# 3

## Control Flow

***

#### C#

    [lang=cs]
    public bool ChangeTire(Car car) {

      var jack = this._repairKitService.GetJack();
      var lugWrench = this._repairKitService.GetLugWrench();

      if (jack == null || lugWrench == null) {
        return this._payphoneRepository().Find().Call(this.owner.BreakDownService);
      }

      while(!car.RemoveWheel(lugWrench, this._owner)) {
        if (this._owner.Strength < 1) {
          throw FrustrationException("Argh, my arm! Its like glued or something!");
        }
      }

      var spare = this._spareTireRepository.Find();
      if (spare == null) {
          throw FrustrationException("But I already took the old one off!");
      }

      return car.AddWheel(lugWrench, spare);
    }

---


#### C#

- Exceptions are an easy way to manage errors.

- Everyone likes loops and especially gotos, right?

- It's all imperative from here, side effects are abound, knots, aspects, spaghetti and meatballs.

- It means we can't compose anything that can be 'done', unless represented explicitly in the structure.

***

#### F#

*)
    let changeTire carToRepair =
      carToRepair
      |> RepairService.getTools
      |> RemoveWheel
      |> AddWheel        
(**

<span style="background-color: pink; padding: 5px;">So declarative.</span> <span style="background-color: gold; padding: 5px;">Much pipe.</span> <span style="background-color: lime; padding: 5px;">Wow.</span> <span style="background-color: blue; padding: 5px;">No imperative.</span>

---

#### F#

- Declarative is good, now we have it for doing things.

- No side effects and gotos so we can reason about where it's going and when.

- Can use pipes and *monads* to descrive errors and execution context.

- Infix operators are a secret language, have to be kept to a minimum.

---

## Special Mention

#### Partial Application

- This is boss, end of, I wish C# had it (without doing Crazy Train currying).

<br/>
<br/>

#### Something something something... monad... infix

- Monad is a fancy maths name for a function that makes linking stuff easier.
- It's all about making your functions seem pure to the consumer.
- Pure functions can flow through a pipe.
- Pipe sections can be built using infix operators.

<br/>
<br/>

[See: Scott Wlaschin and RoP](http://fsharpforfunandprofit.com/rop/)

***

# 4

## Common Patterns

***

### Inversion of Control 
###(Behavioural Patterns)

#### C#

- Mostly through abstracts and interfaces.


    [lang=cs]
    if (WhatYouThoughtWasHappeningDoesnt())
        throw NullReferenceException("Who knows... Woooooooo *trails off*");


#### F#

- Mostly through delegates.
- Functions.

---

### Dependancy Injection 
### (Creational Patterns)

<br/>
<br/>

#### C#

- Root container for BUILDING ALL THE THINGS!


    [lang=cs]
    FactoryServiceFactoryFactory.GetSingletonInstance();

<br/>
<br/>

#### F#

- Mostly through partial application and context.
- Functions.

---

### Adapters and Facades 
### (Structural Patterns)

<br/>
<br/>

#### C#

- Attributes, autofac and interface segregation.


    [lang=cs]
    new Proxy(hopeThisIsntAWebConnection).GetAMassiveObject();

<br/>
<br/>

#### F#

- Probably just functions for this one.

---

### Mutex, Semaphore 
### (Concurrency patterns)

<br/>
<br/>

#### C#

- Locks. Joins. Semaphores. Thread pools.


    [lang=cs]
    var semaphore = new Semaphore(0, 1);
    lock (Int32) {
        Interlocked.Increment(ref someInt32);
    }
    semaphore.Release(someInt32)

<br/>
<br/>

#### F#

- Mailboxes... Which are functions.
- Immutable data so at least if you break, you don't break everything.

***

## Summary

<br/>

### Object Orientation

#### - Large structurally complex domains with simple actions.
#### - Doing all those horrible side effects.

<br/>

### FUNctional Orientation

#### - Small focussed domains with complex control flow.
#### - High degree of paper provable reasoning necessary.

***

# Thanks

### Tweet: @jasond_s
### Email: jason@jasonds.co.uk

*)
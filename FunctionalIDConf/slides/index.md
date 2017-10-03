- title : FUNctional Programming
- description : Introduction to Functional Programming
- author : Jason Dryhurst-Smith
- theme : night
- transition : default

***

# FUNctional Programming

### objects vs functions... FIGHT!

</br>

#### @jasond_s
#### Principle Engineer at Codat.io

***

### A few of my biases

#### 1. **Platform:** 

This is why I am using F# and C# in examples.

#### 2. **Recency Illusion:** 

Functional programming is surrounded by buzz.

#### 3. **Boring enterprise code:** 

I'm not an academic or a hacker, I write boring but hopefully hard working enterprise code.

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

# <div style="font-family: 'SFComicScript' !important; font-size: 250%;">1</div>

## Structure

***

### Class Orientation


---

#### C#

    [lang=cs]
    class SuperDoer : Doing, IDoStuff {
      public SuperDoer(string doing) : base(doing) { }
      public bool DoStuff() => true;
    }

    class LameDoer : Doing, IDoStuff {
      public override string Doing { get; set; }
      public LameDoer(string doing) {
        this.Doing = doing;
      }
      public bool DoStuff() => false;
    }

    class AmazingDoerChecker : IDoerChecker {
      public string WhosDoingIt(IDoStuff stuffdoer) => 
        stuffdoer.DoStuff() ? "Pay Rise" : "P45";
    }

    public void Main(object[] args) =>
      new AmazingDoerChecker()
          .WhosDoingIt(new LameDoer("I am so lazy"));

---

### What is that?

#### C#

- Polymorphism via inheritance.
- Easy to add new 'kinds' of things.
- Mutable, hardware efficient.
- SOLID, although commonly contradictions arise.

---

![Carl Sagan roles his eyes](./images/sagan.gif)

---

### What is that not?

#### C#

- Hard to see the structure of **all the things**.
- Difficult to add new behaviour.
- No 'built-in' way to spec a concurrent model, only parallel.
- When is interface segregation not single responsibility?

---

![Heavy traffic, very confusing](./images/heavy_traffic.gif)

***

### Functional Orientation

#### F#

    [lang=fs]
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

---

### What is that?

#### F#

- Polymorphism via type composition and then 'matching'.
- Easy to add new stuff our things can do.
- Still SOLID if we want it to be.
- Immutable by default, safe and easy to reason about.
- Easy to see the structure of the things.

---

![A cute dog circles a roundabout, smiling.](./images/cute_dog.gif)

---

### What is that not?

#### F#

- Things and what they do can be scattered.
- Not very easy to add new things.
- Recursive structure is not warmly received.
- Immutability is **NOT** hardware efficient.

---

![I swear I have it right this time.](http://imgs.xkcd.com/comics/haskell.png)

***

# <div style="font-family: 'SFComicScript' !important; font-size: 250%;">2</div>

## Composability

#### (It's a word, I looked it up.)

- Why?
- How??
- Where???
- When?????

***

#### C#

    [lang=cs]
    class SuperDoer : Doing, IDoStuff {

      private IWorkService _workService;

      public override string Doing { get; set; }

      public SuperDoer(string doing, IWorkService workService) {
        this.Doing = doing;
        this._workService = workService;
      }

      public bool DoStuff() {
        return this._workService(this.Doing);
      }
    }

---

#### C#

### What is that?

- Structural composition. We can make pretty much any thing out of pretty much any other thing or set of things.

- This *is* really cool and declarative. 

- The car abstraction doesn't need to know about how many bolts a wheel needs, etc etc.

--- 

![Rube Goldberg machine.](./images/rube_goldberg.gif)

---

#### C#

### What is that not?

- We can't compose things we might want to **do**.

- Doesn't allow us to easily specify any dynamics.

--- 

![Rube Goldberg machine.](./images/rube_goldberg_2.gif)

***

#### F#

    [lang=fs]
    type Seats = int
    type Controls = string
    type Body = Seats * Controls
    type Nuts = int
    type Bolts = int
    type Wheel = Nuts * Bolts
    type Wheels = Wheel list

    type WheeledVehicle = Wheels * Body

    type Vehicle =
        | Car of WheeledVehicle
        | Lorry of WheeledVehicle
        | Horse of string

---

### What is that?

#### F#

- We can do a bit of structural composition here to. But... 

- Complex nested or cyclic relationships are _**HARD**_ to represent.

- This is also awesome and declarative but it does not prevent us from doing awesome things, *ahem* functional composition.

#### More on that last one later....

--- 

![A lego brick, made of lego bricks.](./images/lego.gif)

---

### What is that not?

#### F#

- I'm going to be honest with you I am seriously struggling here to find things that are missing here. I guess I haven't introduced much __*doing*__. Interestingly this is the same number of lines of code to describe this whole domain as in the C# example above. Just saying.

#### More on that last one later....


***

# <div style="font-family: 'SFComicScript' !important; font-size: 250%;">3</div>

## Control Flow

***

#### C#

    [lang=cs]
    public bool ChangeTire(Car car) {
      var jack = this._repairKitService.GetJack();
      var lugWrench = this._repairKitService.GetLugWrench();

      if (jack == null || lugWrench == null) {
        return this._payphoneRepository().Find(this._owner.Wallet)
            .Call(this._owner.BreakDownService);
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

### What is that?

- Exceptions are an easy way to manage errors.

- Everyone likes loops and especially GOTOs, right?

- Exceptions are a kind of GOTO... lets be honest.

---

#### C#

### What is that not?

- It's all imperative from here, side effects are abound, knots, aspects, spaghetti and meatballs.

- It means we can't compose anything that can be __*done*__, unless represented explicitly in the structure.

---

![Bossy](./images/bossy.gif)

***

#### F#

<br/>
<span style="background-color: lime; padding: 6px;">Succinct.</span> <span style="background-color: blue; padding: 6px;">Readable.</span> <span style="background-color: gold; padding: 6px;">Many density.</span>
<br/>
<br/>

    [lang=fs]
    let changeTire carToRepair =
      carToRepair
      |> RepairService.getTools
      |> RemoveWheel
      |> AddWheel

<br/>
<br/>
<span style="background-color: pink; padding: 6px;">So declarative.</span> <span style="background-color: gold; padding: 6px;">Much pipe.</span> <span style="background-color: lime; padding: 6px;">Wow.</span> <span style="background-color: blue; padding: 6px;">No imperative.</span>

---

### What is that?

#### F#

- Declarative is good, now we have it for the doing things.

- No side effects and gotos so we can reason about where it's going and when.

- Can use pipes to describe error handling and execution context.

---

![Michelle Obama is confident](./images/confident.gif)

---

### What is that not?

#### F#

- Infix operators are a **secret language**. Lots of meaning in the pipes.

- Sometimes we want and require side effects and to mutate data!

---

![There is secret as the room burns](./images/secret.gif)

---

## Special Mention

#### Partial Application

- This is AWESOME, end of, I wish C# had it.
- No more dependency injection!

<br/>
<br/>

#### Something something something... monad... infix

- It's all about making your functions seem pure to the consumer.
- Pure functions can flow through a pipe.
- Pipe sections can be built using infix operators.

<br/>
<br/>

[See: Railways and... Monads](http://fsharpforfunandprofit.com/rop/)

***

# <div style="font-family: 'SFComicScript' !important; font-size: 250%;">4</div>

## Common Patterns

***

### Behavioural Patterns
#### Inversion of Control 

#### C#

- Mostly through abstracts and interfaces.


    [lang=cs]
    if (WhatYouThoughtWasHappeningDoesnt()) {
        throw NullReferenceException("Who knows... Woooooooo *trails off*");
    }

#### F#

- Mostly through functions.


    [lang=fs]
    let myFunction value injectedFunction =
        doSomething value
        |> injectedFunction

---

### Creational Patterns
#### Dependancy Injection 

#### C#

- Root container for __*constructing all the things!*__


    [lang=cs]
    new FactoryServiceFactoryFactory.GetSingletonInstance();

#### F#

- Mostly through partial application and context, functions.


    [lang=fs]
    let myFunction = 
        doWorkWithInfrastructure myInfrastructure

    let myWork value =
        myFunction value

---

### Structural Patterns
#### Adapters and Facades

#### C#

- Attributes, Interface segregation, Classic Inheritance.


    [lang=cs]
    new Proxy(hopeThisIsntAWebConnection).GetAMassiveObject();

#### F#

- Probably just functions for this one, or a function type.


    [lang=fs]
    let getAMassiveObject search = 
        myInfrastructure search

---

### Concurrency patterns
#### Mutex, Semaphore 

#### C#

- Locks. Joins. Semaphores. Thread pools.


    [lang=cs]
    var semaphore = new Semaphore(0, 1);
    lock (typeof(Int32)) Interlocked.Increment(ref someInt32);
    semaphore.Release(someInt32)

#### F#

- Mailboxes........... Which are functions.


    [lang=fs]
    let someAgent = MailboxProcessor.Start(fun inbox-> 
        let rec messageLoop() = async {
            let! msg = inbox.Receive() // async!
            return! messageLoop()  
            }
        messageLoop() 
        )



***

## Summary

<br/>

### Object Orientation

#### - Large structurally complex domains, big building blocks.
#### - Doing all those horrible side effects.

### FUNctional Orientation

#### - Small focussed domains with complex control flow.
#### - High degree of paper provable reasoning necessary. 

> Can I hear a 'micro service', what what!?

***

<div style="width:33%; height: 100%; display: inline-block; vertical-align: top;">
   <img style="width:50%; display: inline-block; box-shadow: none !important; background: radial-gradient(ellipse farthest-side at 100% 100%,#a1c8d6 10%,#66a9bd 50%,#085078 120%);" src="./images/codat_logo.png" alt="mi logo">
</div>
<div style="width:65%; height: 100%; display: inline-block; text-align: left; padding-top: 10px;">
### <span style="color: #464B4B; font-size: 120%;">Thanks</span>
### <span style="color: #416F85; text-shadow: none; font-size: 75%;">Tweet: @jasond_s</span>
### <span style="color: #416F85; text-shadow: none; font-size: 75%;">Email: jason@codat.io</span>

##### Generation
**[FsReveal](https://github.com/fsprojects/FsReveal)** for slides

##### GIFs and that
**[giphy](https://giphy.com)** for all the great gifs

</div>
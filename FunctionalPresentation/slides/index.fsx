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

## What is FsReveal?

### Generation

[reveal.js](http://lab.hakim.se/reveal-js/#/) presentation from [markdown](http://daringfireball.net/projects/markdown/)

### Formatting

[FSharp.Formatting](https://github.com/tpetricek/FSharp.Formatting) for markdown parsing

> **Atwood's Law**: any application that can be written in JavaScript, will eventually be written in JavaScript.


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

1. Polymorphism via inheritance.
2. Easy to add new 'kinds' of things.
3. Can code to ALL the interfaces.
4. Mutable, efficient.

---

### What is that not?

#### C#

1. Simple to see the structure of the things.
2. Easy to add new behaviour.
3. Can code to AAALLLL the interfaces.
4. Safe in a concurrent model, mutex anyone?

![Umm, guys I'm trying to get through here.](./images/deadlock.jpg)

***

## What you need to know.

#### F#

1. A function is a value.
2. A function is a thing.
3. A function can be a pattern or interface.
4. <del>Lambda calculus.</del>
5. <del>Monads and monoids.</del>
6. Basically it's all functions.


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
(*** include-value: whosDoingIt (Super "I'm so busy its crazy.") ***)
(**

---

### What is that?

#### F#

1. Polymorphism via type composition.
2. Easy to add new stuff our things can do.
3. Can code to any of the type interfaces.
4. Immutable, safe and easy to reason about.
5. Easy to see the structure of the things.

---

### What is that not?

#### F#

1. Things and what they do can be scattered.
2. Easy to add new things.
3. Can only code to the type (WHY WON'T YOU COMPILE!) .
4. Immutability is not memory and CPU efficient.

![I swear I have it right this time.](http://stream1.gifsoup.com/view1/1342076/i-hate-justin-beiber-o.gif)

***

## Composability
#### (It's a word, I looked it up.)

- Why?
- How?
- Where??
- When?????

***

#### C#

 Structural composition. We can make pretty much any thing out of pretty much any other thing or set of things.

 A car has wheels, wheels have nuts and nuts have bolts.

 The car abstraction doesn't need to know about how many bolts a wheel needs.

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

This is really cool and declarative.

But it means we can't compose anything that can be 'done'.

It's all imperative from here.

    [lang=cs]
    public bool ChangeTire(Car car) {

      var jack = this._repairKitService.GetJack();
      var lugWrench = this._repairKitService.GetLugWrench();

      if (jack == null || lugWrench == null){
        return this._payphoneRepository().Find().Call(this.owner.BreakDownService);
      }

      while(!car.RemoveWheel(lugWrench, this._owner)){
        if (this._owner.Strength < 1){
          throw FrustrationException("Argh, my arm! Its like glued or something!");
        }
      }

      var spare = this._spareTireRepository.Find();
      if (spare == null) {
          throw FrustrationException("But I already took the old one off!");
      }

      return car.AddWheel(lugWrench, spare);
    }


***

#### F#

We can do a bit of structural composition here to.

This is purely structural to. There is no mixing of concerns. Human readable and no noise.

But... it distances itself from what it's all doing. Complex nested cyclic relationships are _**HARD**_ to represent.

    [lang=fs]
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

---

#### F#

This is also awesome and declaritive but it does not prevent us from doing awesome things. Like functional composition.

The seperation of concerns means we can now compose DOING as well things.

    [lang=fs]
    let changeTire carToRepair =
      carToRepair
      |> RepairService.getTools
      |> RemoveWheel
      |> AddWheel

So declarative. Much pipe. Wow. No imperative.

How is this possible?

***

## Partial Application

### Something something something... monad.

1. Monad is a fancy maths name for a function that makes linking stuff easier.
2. It's all about making your functions seem pure.
3. Pure functions can flow through a pipe.

***

## Railways!


### Sort of.

#### Go to the VS solution!


*)
(**
- title : FUNctional Programming
- description : Introduction to Functional Programming
- author : Jason Dryhurst-Smith
- theme : night
- transition : default

***

# Processing Stuff With F#

### I thought we hated state?

</br>

#### By Jason, that's me @jasond_s.


***

### Class Orientation

#### C#

    [lang=cs]
    class SuperDoer : Doing, IDoStuff {
      public Result Process() {
        return new Result("Data");
      }

    }

---

### What is that?

#### C#

1. Some stuff probably.

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


***

### FsLab

#### F#

 Structural composition. We can make pretty much any thing out of pretty much any other thing or set of things.

 A car has wheels, wheels have nuts and nuts have bolts.


---

#### F#

- Things
- Other things.


***

## Code!

#### Go to the VS solution!


*)
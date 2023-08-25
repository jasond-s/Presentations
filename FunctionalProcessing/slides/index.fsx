(**
- title : FUN-ctional Programming Is Sic Bruv
- description : Introduction to Functional Programming
- author : Jason Dryhurst-Smith
- theme : night
- transition : default

***

#### I heard you liked virtual machines in your virtual machines yo
#### here's some F# running in Fable on your Javascript presentation

*)
type Programming = string
type Paradigm =
    | Functional of Programming
    | ObjectOriented of Programming

let careerProgression thing =
  match thing with
  | Functional _ -> "Pay Rise"
  | ObjectOriented _ -> "P45"
  | _ -> "Are you C or drunk or something?"

careerProgression (Functional "I'm so hot right now")
(*** include-value: careerProgression (Functional "I'm so hot right now") ***)
(**

---

# Isn't that cool


*)
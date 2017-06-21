(**
- title : DRY KISS
- description : SOLID is dead long live other stuff
- author : Jason Dryhurst-Smith
- theme : night
- transition : default

***

> "Technology can bring benefits if, and only if, it diminishes a limitation" - *Eli Golduatt "Beyond the Goal*"

---

![](/images/cinammon_challenge.gif)

***


## SOLID

#### How do they work?

***

### Single responsibility

### Each thing should do one and only on thing.

*"Only one thing to change when requirements chnage."*

---

### Single responsibility

#### How single is a responsibility?

#### Is an auto property breaking this rule?

*"Is it an encapsulation that 'makes sense' and can the whole thing fit in your head?"*

***

## Open Closed

#### Open to extension and closed to modification.

<br/><br/>

*"When requirements change extend the system for the new functions."*

*"Don't change code that works."*

---

## Open Closed

#### This is retarded.

<br/><br/>

*"When requirements change **CHANGE** the system for the new functions."*

*"Code rarely exists in a vacuum, don't be frightened of changing it."*

***

## Liskov Substitution

#### Strong behavioural subtyping. Subtype provides all desireable behaviours.

*"Hierarchical structure implies behaviour for later extension."*

---

## Liskov Substitution

#### Polymorphic dancing 'is-a' 'has-a'

*"Composition is always easier to reason about that inheritace... #diamondproblem"*

*"Even functional polymorphism is secretly composition and pattern matching."*

***

## Interface Segregation

#### Many small interfaces better than one big one.

*"Design to abstraction, no client knows about things it does not use, remember rule letter 'S'."*

---

## Interface Segregation

#### Anything is better than god objects.

#### Suffers everthing that rule 'S' does.

*"Don't just create abstractions to then create chains between you and your DI."*

*** 

## Dependency Inversion

#### High level components should not depend on low level componenets.

*"Interfaces should not depend on details in the implementations"*

---

## Dependency Inversion

#### Yeah, ok, I guess this sort of makes sense.

#### End up in abstraction soup for every possible eventuality.

*"We are not designing universally re-usable low level libraries. Re-use is overrated, write code you need for the situation you are in. Take BCrypt as cautionary tale!"*

***

# DRY your KISS

*"Don't needlessly repeat yourself, given, but code is far more maintainable, changeable, and pleasnt to work with when it is simple."*

*"If the abstraction can fit in your head and logically sits together, that's fine... breaking up is usally easier than combining."*

## Write simple code!

***


*)
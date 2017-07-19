(**
- title : DRY KISS
- description : SOLID is dead long live other stuff
- author : Jason Dryhurst-Smith
- theme : night
- transition : default

***

> "Technology can bring benefits if, and only if, it diminishes a limitation" - *Eli Golduatt "Beyond the Goal*"

---

#### So lets look at some common Practices (big p) in the form of programming acronyms, and see what limitations they are diminishing.

---

![](/images/cinammon_challenge.gif)

***

## SOLID

#### How do they work?

***

### Single responsibility

<br/><br/>

#### Each thing should do one and only on thing.

*"Only one thing to change when requirements change. #utopia"*

---

### Single responsibility

<br/><br/>

#### How single is a responsibility?

#### Is an auto property breaking this rule?

*"Is it an encapsulation that 'makes sense' and can the whole thing fit in your head?"*

*"Equally vague but pragmatism is key, refer to the business, not the rule."*

***

## Open Closed

<br/><br/>

#### Open to extension and closed to modification.

*"When requirements change extend the system for the new functions."*

*"Don't change code that works."*

---

## Open Closed

<br/><br/>

#### This is retarded.

<br/><br/>

*"When requirements change **CHANGE** the system for the new functions."*

*"Code rarely exists in a vacuum, don't be frightened of changing it."*

***

## Liskov Substitution

<br/><br/>

#### Strong behavioural subtyping. Subtype provides all desireable behaviours.

*"Hierarchical structure implies behaviour for later extension."*

---

## Liskov Substitution

<br/><br/>

#### Polymorphic dancing; strategies of strategies into managers for factories.

*"Composition is always easier to reason about that inheritace... #diamondproblem"*

*"Functional polymorphism is secretly composition and pattern matching!"*

***

## Interface Segregation

<br/><br/>

#### Many small interfaces better than one big one.

*"Design to abstraction, no client knows about things it does not use, remember rule letter 'S'."*

---

## Interface Segregation

<br/><br/>

#### Anything is better than god objects.

#### Suffers everthing that rule 'S' does.

*"Creating all these abstractions just creates chains between you and your DI."*

*"Premature seperation breaks the 'change just one thing' utopia."*

*** 

## Dependency Inversion

<br/><br/>

#### High level components should not depend on low level components.

*"Interfaces should not depend on details in the implementations"*

---

## Dependency Inversion

<br/><br/>

#### Yeah, ok, I guess this sort of makes sense.

#### But we can easily end up in abstraction soup.

*"We are not designing universally re-usable low level libraries. Re-use is overrated, write code you need for the situation you are in. Take BCrypt as cautionary tale!"*

***

# DRY your KISS

*"Don't needlessly repeat yourself, given, but code is far more maintainable, changeable, and pleasnt to work with when it is simple."*

*"If the abstraction can fit in your head and logically sits together, that's fine... breaking up is usally easier than combining later in code or in your head when you are reading it."*

---

# Write simple code!

### Readability and changeability are far more useful than terseness or artistic structure.

---

*If you still want to write sexy code, there are loads of open source projects in need of framework devs.*

***

*)
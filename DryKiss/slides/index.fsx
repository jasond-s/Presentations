(**
- title : DRY KISS
- description : SOLID is dead long live other stuff
- author : Jason Dryhurst-Smith
- theme : night
- transition : default

***

> "Technology can bring benefits if, and only if, it diminishes a limitation" - *Eli Golduatt "Beyond the Goal*"

---

#### So lets look at one common Practice
#### (a well known programming acronym)
#### and see what limitations it is diminishing

***

## SOLID

#### How do they work?

***

### Single responsibility

<br/><br/>

#### Each thing should do one and only on thing.

<br/><br/>

*"Only one thing to change when requirements change. #utopia"*

---

### Single responsibility

<br/><br/>

#### How single is a responsibility?

#### Is a C# auto property breaking this rule?

<br/><br/>

**OK, so that is equally vague, but...**

*"Is it an encapsulation that 'makes sense' to the business not the programming language and can the whole thing fit in your head?"*

***

## Open Closed

<br/><br/>

#### Open to extension and closed to modification.

<br/><br/>

*"When requirements change extend the system for the new functions"*

*"Don't change code that works."*

---

## Open Closed

<br/><br/>

#### This is just silly.

<br/><br/>

*"When requirements change **CHANGE** the system for the new functions, state, and behaviours"*

*"Code rarely exists in a vacuum, don't be frightened of changing it"*

#### Fear is the absolute worst

***

## Liskov Substitution

<br/><br/>

#### Strong behavioural subtyping. 
#### Subtype provides all desireable behaviours.

<br/><br/>

*"Hierarchical structure implies whole system behaviour for later extension"*

---

## Liskov Substitution

<br/><br/>

#### Polymorphic dancing

<br/><br/>

*"Composition is always easier to reason about that inheritace"*

---

## you be having #diamondproblems I feel bad for you son, you got 99 classes but the this overload ain't the right one

---

## BONUS FACT: 

### Functional polymorphism is secretly composition and pattern matching!

***

## Interface Segregation

<br/><br/>

#### Design against the smallest needed abstraction

<br/><br/>

*"Design to abstraction, no client knows about things it does not use, remember 'Single responsibility'"*

---

## Interface Segregation

<br/><br/>

#### Anything is better than god objects

<br/><br/>

*"Creating all these micro abstractions just creates messy chains between you and your, probably very dominant, DI"*

*"Premature seperation leads you away from the 'change just one thing' utopia. Fiddling with all the related codes structure, and not behaviour"*

*** 

## Dependency Inversion

<br/><br/>

#### High level components should not depend on low level components.

<br/><br/>

*"Interfaces should not depend on details in the implementations"*

---

## Dependency Inversion

<br/><br/>

#### Yeah, ok, I guess this sort of makes sense.

--- 

### However!

#### We can easily end up in abstraction soup

#### Strategies for factories into managers of services.

<br/><br/>

*"We are probably not designing re-usable low level libraries."* 

*"Re-use is overrated, write code you need for the situation you are in!"*

***

## Did SOLID diminish a limitation?

<br/><br/>

#### Seemed to just define a set of arbitrary and vague rules
#### The world the rules were built in has changed

<br/><br/>

#### For the better

---

# DRY 

*"Don't needlessly repeat yourself, but code is far more maintainable, changeable, and pleasant to work with when it is concious of it's context."*

# KISS

*"If the abstraction can fit in your head and logically sits together, that's fine, at lby me. Breaking up is usually easier than combining later, in code OR in your head when you are reading it."*

---

# Write simple, clear, code!

<br/><br/>

### Readable and flexible code is the most useful thing to your business

### Better a bit 'wrong' today, if it means it's easier to get a bit more 'right' tomorrow.

***

<div style="width:33%; height: 100%; display: inline-block; vertical-align: top;">
   <img style="width:50%; display: inline-block; box-shadow: none !important; background: radial-gradient(ellipse farthest-side at 100% 100%,#a1c8d6 10%,#66a9bd 50%,#085078 120%);" src="./images/codat_logo.png" alt="codat logo">
</div>
<div style="width:65%; height: 100%; display: inline-block; text-align: left; padding-top: 10px;">
### <span style="color: #464B4B; font-size: 120%;">Thanks</span>
### <span style="color: #416F85; text-shadow: none; font-size: 75%;">Tweet: @jasond_s</span>
### <span style="color: #416F85; text-shadow: none; font-size: 75%;">Email: jason@codat.io</span>

##### Generation
**[FsReveal](https://github.com/fsprojects/FsReveal)** for slides

##### Hiring
**[Codat](https://codat.io)** is looking for passionate C# devs

</div>

*)
(**
- title : Functional DOM with Elm
- description : Introduction to Functional Programming in Elm
- author : Jason Dryhurst-Smith
- theme : night
- transition : default

***

# Learning to embrace <strike> events </strike> Elm

### We want speed!
### When do we want it!
### Yesterday!

---

### What's coming up?

1. Who am I?
<br><br>
2. What was my problem?
<br><br>
3. How did I learn to solve that kind of problem?
    - Intro to FP.
    - Intro to Elm.
<br><br>
4. How can you solve that problem yourselves?
    - Some working code.
<br><br>
5. What did I do to solve my particular problem?

---

### Who am I?

1. Engineer for nearly 10 years.
    - Electronics -> Web

2. Work for MarketInvoice.
    - We help SMEs with cash flow using their existing invoices.

3. Full disclosure.
    - I'm not a master and I'm not a contributor, I'm just a fan.

***

### My list of front-end problems

1. Two way binding?
2. Where is that state again?
3. Wait what kind of an object are you?
4. `{} + [] === 0; [] + {} === {};` <---- wut?
5. Are views even HTML anymore? Should they be?
6. `Something.prototype.botheringMe = someFuncThatIsnt`
7. Why hasn't this MVC model moved on!
8. Angular and similar can be................. slow.

---

#### Learn how someone else is tackling their problems!

<div style="width:90%; height: 90%; display: inline-block; vertical-align: top;">
   <img style="width:90%; display: inline-block; box-shadow: none !important;" src="./images/comfort-zone.jpg" alt="comfort zone">
</div>

***

# Functional Ideals

---

<div style="width:90%; height: 90%; display: inline-block; vertical-align: top;">
   <img style="width:90%; display: inline-block; box-shadow: none !important;" src="./images/its-hard.gif" alt="comfort zone">
</div>

---

<div style="width:90%; height: 90%; display: inline-block; vertical-align: top;">
   <img style="width:90%; display: inline-block; box-shadow: none !important;" src="./images/kittens.gif" alt="comfort zone">
</div>

---

### Type System

There tends to be 4 mains 'kinds' of type.

1. Alias.
    - Naming a kind of primitive.
2. Union.
    - Think of it as a label or tag.
3. Tuple.
    - It's kind of a bucket for things.
4. Record.
    - A set of named properties.

<br/><br/>

#### Plus the common useful primitives; 

Int, Float, String, Array, Dict and (linked) List

---

### Immuatble

The languages usually enforce immutability. Comparisons tend to be structural by default and data tends to be copied. Which is good for concurrency.

<br/>
<br/>

<div style="text-align: left; padding-left:100px;">

Also, therefore in Elm;

If something is `referencially` the same.

It must be `structurally` the same.

_This is how virtual-dom does it's magic._

</div>

---

### Purity

The function always returns the same result when given the same set of arguments, there are no side effects (with some I/O caveats).

<br/>
<br/>

<div style="text-align: left; padding-left:100px;">

1. No side effects: 
    - Means this is easily tested. 
    - Also easy to 'reason' about.
2. There is no _'state'_, just functions.
3. Elm has a runtime that deals with all the pesky 'real world' side effects.

</div>

***

## What is ELM

<div style="text-align: left; padding-left: 10%;">
#### 1. Installed with NPM.
#### 2. Transpiles to Javascript.
#### 3. Runtime packaged with build files.
#### 4. Functional.
#### 5. Reactive.
#### 6. Strongly typed, with generics.
### 7. ????
## 8. Profit.
</div>

---

## Elm Architecture

#### Single direction for flow of information.

#### 1. Event driven (signals send actions to an address) - ng.emit
#### 2. Single source of data (foldp) - ng.servce
#### 3. Modular abstractions (filters for your 'address space') - ng.on
    
    [lang=erlang]
          Signals -> Functional -> Combinatorial -> Magic
           ____________
          |  ________  |
          | |        | | Actions (messages)
          | |        v v                               Virtual DOM
          | |     ----------                           -----------
          | |    | Run Time | App state (update) ---> |  (view)   |
          | |     ----------                           -----------
          | |______________________________________________| |         
          |__________________________________________________| 

---

# <div style="font-family: 'SFComicScript' !important; color: #00ABEC;">SHOW ME</div>
# <div style="font-family: 'SFComicScript' !important; color: #00ABEC;">THE CODE!</div>

---

### Event -> Update -> Model -> View

---

### Composition

##### Composing the DOM

---

### Subscriptions

##### For extrnal input

---

### Commands

##### For side effects

---

### Tasks

##### For async work

---

### All working together!

***

### Elm Take Homes
<br/><br/>
#### 1. Single direction for flow of information.
#### 2. No 'floating' state.
#### 3. Change only when you need to.
#### 4. Rich type system.

---

### Doing that but, like, with angular?
<br/><br/>
#### 1. Event driven - ng.emit
#### 2. Single source of data - ng.servce
#### 3. Reactive - ng.on / $watch
#### 4. Use Typescript.
<br/>
... Or of course React with Redux!

---

<div style="width:50%; height: 50%; display: inline-block; vertical-align: top;">
   <img style="width:90%; display: inline-block; box-shadow: none !important;" src="./images/try-it.jpg" alt="comfort zone">
</div>

***

<div style="width:33%; height: 100%; display: inline-block; vertical-align: top;">
   <img style="width:90%; display: inline-block; box-shadow: none !important;" src="./images/miLogo.png" alt="mi logo">
</div>
<div style="width:65%; height: 100%; display: inline-block; text-align: left; padding-top: 10px;">
### <span style="color: #464B4B; font-size: 120%;">Thanks</span>
### <span style="color: #FFA55D; text-shadow: none; font-size: 75%;">Tech@MI: tech.marketinvoice.com</span>
### <span style="color: #FFA55D; text-shadow: none; font-size: 75%;">Tweet: @jasond_s</span>
### <span style="color: #FFA55D; text-shadow: none; font-size: 75%;">Email: jason@jasonds.co.uk</span>

##### Get started with elm.
**[Elm Lang](http://elm-lang.org/)** for all your Elm needs.

##### Doing in with javascript
**[reactjs/redux](https://github.com/reactjs/redux)** was based on the Elm runtime, but works in JS.
</div>

*)
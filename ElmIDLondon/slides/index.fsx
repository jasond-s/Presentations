(**
- title : Functional DOM with Elm
- description : Introduction to Functional Programming in Elm
- author : Jason Dryhurst-Smith
- theme : night
- transition : default

***

# Learning to embrace Elm

### We want speed!
### When do we want it!
### Yesterday!
<br/>
### Also FRP.

---

### What's next?

1. Who am I.
<br><br>
2. What my problem was.
<br><br>
3. What tool I picked to learn how  to solve that problem 
    - hint: it was Elm.
<br><br>
4. Introduction to solving that problem for yourself.
    - Intro to FP.
    - Intro to Elm.
    - Some working code.
<br><br>
5. What I actually did to solve my problem.

***

### Who am I?

1. Engineer for nearly 10 years... crap...really?
    - Electronics.
    - Firmware.
    - Embedded.
    - Desktop.
    - Web? ... I don't know what software is anymore.

2. Work for MarketInvoice.
    - We help SMEs with cash flow using their existing invoices.

***

### My list of problems

1. Two way binding?
2. Where is that state again?
3. Wait what kind of an object are you?
4. `{} + [] === 0; [] + {} === {};` <---- wut?
5. Are views even HTML anymore? Should they be?
6. `Something.prototype.botheringMe = someFuncThatIsnt`
7. Why hasn't this MVC model moved on!
8. Angular and similar can be........ slow.
9. I've used a functional approach to great success on the server.

---

<div style="width:90%; height: 90%; display: inline-block; vertical-align: top;">
   <img style="width:90%; display: inline-block; box-shadow: none !important;" src="./images/comfort-zone.jpg" alt="comfort zone">
</div>

***

## What is ELM

<div style="text-align: left; padding-left: 10%;">
#### 1. Installed with NPM.
#### 2. Compiles to Javascript.
#### 3. Runtime packaged with build files.
#### 4. Functional.
#### 5. Reactive.
#### 6. Strongly (dial) typed.
### 7. ????
## 8. Profit.
</div>

***

# Functional Ideals

---

### Types

There tends to be 3 mains 'kinds' of type.

1. Union.
    - Think of it as a label or tag.
2. Tuple.
    - It's kind of a bucket for things.
3. Record.
    - A set of named properties.

<br><br>

Plus the standard useful primitives, numbers, strings, arrays and lists.

---

### Immuatble

The languages usually enforce immutability, therefore;

If something is _**referencially**_ the same.

It must be _**structurally**_ the same.

Therefore, comparisons tend to be structural and data tends to be copied.

---

### Purity

#### Input -> Output. 

- No side effects means this is hugely testable. 
- There no _state_, just functions.

***

## Best Practice For Using It

#### It's literally included in the box, batteries and everything.

#### The ELM Architecture Principles, these are sensible general purpose rules, made real (it's basically FRP, Rxjs, or React's Flux).

# Views

---

### Rendering

#### DOM rendering is rubbish in most frameworks sometimes we have to balance fluid UI with compelx UI.
#### The Elm HTML rendering pipeline is based on the [vitual DOM principle](https://github.com/Matt-Esch/virtual-dom) (just like React.js).
#### Canvas and SVG are the same as classic DOM, can I hear interaction and visually rich UX, what what!

---

#### Elm-HTML

This is a useful package for getting the virtual dom going, exposing;

- **view** - our UI expressed as a function.
- **events** and **attributes** - used for interacting with the virtual DOM.

Everything here is a function and can be combined just like other functions. Build your widgets and apps out of other widgets and apps.

---

# Control

---

### Architecture

### Single direction flow of information.

#### Event driven (signals send actions to an address) - ng.emit
#### Single source of data (foldp) - ng.servce
#### Modular abstractions (filters for your address space) - ng.on
    
    [lang=erlang]
          Signals -> Functional -> Combinatorial -> Magic
           _________
          |  _____  |
          | |     | | Actions (events)
          | |     v v                                      Virtual DOM
          | |     -------                                  -----------
          | |    | foldp | App state (data service) ----> | Rendering |
          | |     -------                                  -----------
          | |________________________| |
          |____________________________| Filters (address)

---

#### StartApp.Simple

This is a useful package for getting the runtime going, exposing;

- **start initialState** - foldp from next tick or signal and initial state.
- **update** - next tick, or next signal.

Once again everything here is a function so its dead easy to combine your ideas.

***

### Code

    [lang=haskell]
    type alias Model = Int

    type Action = Increment | Decrement

    update : Action -> Model -> Model
    update action model = 
        case action of 
            Increment -> model + 1
            Decrement -> model - 1

    view : Signal.Address Action -> Model -> Html
    view address model = 
        div []
            [ button [ onClick address Decrement ] [ text "-" ]
            , div [ countStyle ] [ text (toString model) ]
            , button [ onClick address Increment ] [ text "+" ]
            ]

    countStyle : Attribute
    countStyle =
        style
            [ ("font-size", "20px")
            , ("font-family", "monospace")
            , ("display", "inline-block")
            , ("width", "50px")
            , ("text-align", "center")
            ]

---

## Modules

#### We have modules for packaging code and sharing (no need for requirejs, systemjs, browserfy, babel, ES6 modules, angular, blah blah blah BLAH).

---

## Types

#### All the goodness of an expressive functional type system, including records, aliases and unions.

---

## Functions

#### Naturally

---

## Style

#### VERY similar to F# (aweseome)

***

## Alternatives

#### [FunScript](http://funscript.info/)

This is cool, but it is just a type provider. This is the 'rule of least power'.

#### [WebSharper](http://websharper.com/#void)

This is the full kaboodle, server and client defined in F#. 

#### [PureScript](http://www.purescript.org/)

This is basically haskell in the browser. Halogen provides SPA and FRP holy grail, but is classically functional (unapproachable).

***

***

<div style="width:33%; height: 100%; display: inline-block; vertical-align: top;">
   <img style="width:90%; display: inline-block; box-shadow: none !important;" src="./images/miLogo.png" alt="mi logo">
</div>
<div style="width:65%; height: 100%; display: inline-block; text-align: left; padding-top: 10px;">
### <span style="color: #464B4B; font-size: 120%;">Thanks</span>
### <span style="color: #FFA55D; text-shadow: none; font-size: 75%;">Tech@MI: tech.marketinvoice.com</span>
### <span style="color: #FFA55D; text-shadow: none; font-size: 75%;">Tweet: @jasond_s</span>
### <span style="color: #FFA55D; text-shadow: none; font-size: 75%;">Email: jason@jasonds.co.uk</span>

##### Generation
**[reveal.js](http://lab.hakim.se/reveal-js/#/)** presentation from [markdown](http://daringfireball.net/projects/markdown/)

##### Formatting
**[FSharp.Formatting](https://github.com/tpetricek/FSharp.Formatting)** for markdown parsing

##### Railway Oriented Design
**[Scott Wlaschin](http://fsharpforfunandprofit.com/)** F# for fun and profit
</div>

*)
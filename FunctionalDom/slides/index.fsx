(**
- title : Functional DOM with Elm
- description : Introduction to Functional Programming in Elm
- author : Jason Dryhurst-Smith
- theme : night
- transition : default

***

# Functional DOM with Elm

#### We want speed!
#### When do we want it!
#### Yesterday!
<br/>
#### Also FRP.

***

## ELM

#### Installed with NPM.
#### Compiles to Javascript.
#### Runtime packaged with build files.
#### ????
#### Profit.

***

## Features

#### Statically typed.
#### Simple module system (ES6-ish).
#### Purist functional approach.
#### FAST!

---

#### Purity

Good old functional languages. 

Input -> Output. 

No side effects means this is hugely testable and *easily optimised*.

---

#### Immuatble

The language enforces immutability, therefore;

If something is _**referencially**_ the same.

It must be _**structurally**_ the same. 

Virtual-Dom diffs are trivial to find.

***

## Best Practice For Using It

#### The ELM Architecture Principles, these are sensible general purpose rules, made real (it's basically FRP, Rxjs, or React's Flux)

---

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

#### We have modules for packaging code and sharing (no need for requirejs, systemjs, browserfy, babel, ES6 modules, angular, blah blah blah BLAH)

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

*)
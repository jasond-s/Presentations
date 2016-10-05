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

1. **1** Who am I.
<br><br>
2. **2** What my problem was.
<br><br>
3. **3** What tool I picked to learn how to solve that problem 
    - hint: it was Elm.
<br><br>
4. **4** Introduction to solving that problem for yourself.
    - Intro to FP.
    - Intro to Elm.
    - Some working code.
<br><br>
5. **5** What I actually did to solve my problem.

---

### Who am I?

1. **1** Engineer for nearly 10 years... crap...really?
    - Electronics -> Web

2. **2** Work for MarketInvoice.
    - We help SMEs with cash flow using their existing invoices.

***

### My list of front-end problems

1. **1** Two way binding?
2. **2** Where is that state again?
3. **3** Wait what kind of an object are you?
4. **4** `{} + [] === 0; [] + {} === {};` <---- wut?
5. **5** Are views even HTML anymore? Should they be?
6. **6** `Something.prototype.botheringMe = someFuncThatIsnt`
7. **7** Why hasn't this MVC model moved on!
8. **8** Angular and similar can be........ slow.

---

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

1. **1** Alias.
    - Naming a kind of primitive.
2. **2** Union.
    - Think of it as a label or tag.
3. **3** Tuple.
    - It's kind of a bucket for things.
4. **4** Record.
    - A set of named properties.

<br><br>

Plus the common useful primitives, numbers, strings, arrays and lists.

---

### Immuatble

The languages usually enforce immutability, therefore;

If something is _**referencially**_ the same.

It must be _**structurally**_ the same.

Therefore, comparisons tend to be structural by default and data tends to be copied. Which is good for concurrency 

(this doesn't matter in the DOM of course).

---

### Purity

#### Input -> Output. 

- No side effects: 
    - Means this is hugely testable. 
    - Also easy to 'reason' about.
- There is no _'state'_, just functions.

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

# Control

---

### Architecture

### Single direction for flow of information.

#### 1. Event driven (signals send actions to an address) - ng.emit
#### 2. Single source of data (foldp) - ng.servce
#### 3. Modular abstractions (filters for your 'address space') - ng.on
    
    [lang=erlang]
          Signals -> Functional -> Combinatorial -> Magic
           _________
          |  _____  |
          | |     | | Actions (messages)
          | |     v v                                Virtual DOM
          | |     -------                            -----------
          | |    | foldp | App state (update) ----> |  (view)   |
          | |     -------                            -----------
          | |____________________________________________| |         
          |________________________________________________| 

---

### Simple App

    [lang=haskell]
    import Html exposing (..)
    import Html.Events exposing (onClick)

    type alias Model = Int

    type Action = Increment | Decrement

    update : Action -> Model -> Model
    update action model = 
        case action of 
            Increment -> model + 1
            Decrement -> model - 1

    view : Model -> Html
    view model = 
        div []
            [ button [ onClick Decrement ] [ text "-" ]
            , div [ countStyle ] [ text (toString model) ]
            , button [ onClick Increment ] [ text "+" ]
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
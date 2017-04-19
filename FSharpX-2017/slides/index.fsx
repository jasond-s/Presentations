(**
- title : FSharp eXchange 2017
- description : A few notes from fsharpx
- author : Jason Dryhurst-Smith
- theme : night
- transition : default

**********************************************

# F# eXchange 
## 2017

**********************************************

### State of the FsNation

1. [F# 4.1 - Loads of cool new features.](https://blogs.msdn.microsoft.com/dotnet/2017/03/07/announcing-f-4-1-and-the-visual-f-tools-for-visual-studio-2017-2/)
2. [Fable - F# exists without .Net on the JSVM.](http://fable.io/)
3. [Ionide - Tooling for F# on VsCode and Atom](http://ionide.io/)
4. [New RFC system for language development.](https://github.com/fsharp/fslang-design)
5. dotnet core, obvs

**********************************************

## dotnet Tooling

*)
(*** hide ***)
#r "../packages/FSharp.Plotly/lib/net40/FSharp.Plotly.dll"
#r "../packages/FSharp.Plotly/lib/net40/FSharp.Care.dll"

open FSharp.Plotly 
  
let x = [0.5; 1.; 1.5; 2.;   3.;  3.5 ; 4.]
let y2 = [2.; 10.; 50.;  200.; 50.;  10.; 2.]
let y1 = [2.; 10.; 50.;  200.; 100.;  80.; 75.]

let ls = ["Twinkle In A Developers Eye"; "Some Script Somewhere"; "In Alpha Development";  "In Beta Development"; "Release Candidate";  "Release"; "Should Have Figured This Out By Now Guys"]

let red = FSharp.Care.Colors.Table.Office.red
let blue = FSharp.Care.Colors.Table.Office.blue

[
  Chart.Spline(x,y1,Name="dotnet")  
  |> Chart.withMarkerStyle(Color=red)  
  |> Chart.withLineStyle(Width=2);
  Chart.Spline(x,y2,Labels=ls,Name=".NET") 
  |> Chart.withMarkerStyle(Color=blue)   
  |> Chart.withLineStyle(Width=2)
]
|> Chart.Combine
|> Chart.withX_AxisStyle("TIME")
|> Chart.withY_AxisStyle("TOOL CHURN")
//|> Chart.Show

(**

----------------------------------------------

### Software install management

1. chocolatey
2. dotnet-cli
3. npm
4. yarn
5. yeoman
6. webpack
7. forge
8. scoop
9. paket
10. nuget
11. visual studio
12. VsCode
13. with ionide

----------------------------------------------

### Decernable development benefits

1. All from the command line
2. ?
3. Profit

----------------------------------------------

### Decernable business benefits

1. uuuuuuuhhhhhhhhh?
2. something
3. something
4. productivity?

----------------------------------------------

#### blah blah blah, in my day, blah, blah... *trails off*
#### V
![dino](/images/dino.gif)
##### Jason Dryhurst-Smith - Artitst's representation.

----------------------------------------------

#### Visual studio still reigns supreme
![dino](/images/dino_2.gif)
#### #dontbelievethehype

**********************************************

## Actual Useful Stuff


**********************************************

# [NCrunch](http://www.ncrunch.net/)

**********************************************

# Expecto

---------------------------------------------

*)

#r "../packages/Expecto/lib/net40/Expecto.dll"

open Expecto

let tests =
  [
    testCase  "one test" <| fun _ -> Expect.equal (2+2) 4 "2+2"

    testCase  "two test" <| fun _ -> Expect.equal (2+3) 4 "2+2"

    testAsync "it also does async" {
      let! x = async { return 4 }
      Expect.equal x (2+2) "2+2"
    }
  ]
  |> testList "A group of tests" 

runTests defaultConfig tests
(**

*)

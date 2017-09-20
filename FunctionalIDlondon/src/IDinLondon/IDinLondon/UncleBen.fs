namespace IDinLondon

module Ub =

    open IDinLondon.``Call for help!``
    
    // Lets pretend everything is maths.

    let fy z = 2.0 ** z

    let fx x = x |> fy

    let (<||>) a b =
        fx a + b
    
    let sq z = 3.0 <||> 2.0 <||> 1.0 |> fun x -> x + z


    // Lets pretend seq is ok to use everywhere.

    type ArrayStats = {
        Sum: int
        Mean: int
        Mode: int
    }

    let myCoolArray = [| [|1;2;3;3;4;5|]; [|1;2;3;3;4;5|]; [|1;2;3;3;4;5|] |]
                     
    let statsForArr arr = {
        Sum = arr 
            |> Seq.map (fun i -> Seq.sum i) |> Seq.sum;
        Mean = arr 
            |> Seq.collect ident |> Seq.map asFloat |> Seq.toList |> List.average |> int;
        Mode = arr 
            |> Seq.collect ident |> Seq.countBy ident |> Seq.fold                                     
            (fun (cp, lst) (item, c) ->                 
                if c > cp then (c, [item])              
                elif c = cp then (c, item :: lst)       
                else (cp,lst)
            )                          
            (0, [0]) |> snd |> Seq.head 
    }

    let result = statsForArr myCoolArray
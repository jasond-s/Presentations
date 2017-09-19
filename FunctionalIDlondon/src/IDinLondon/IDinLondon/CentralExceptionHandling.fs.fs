namespace IDinLondon

module Ceh = 

    open IDinLondon.Dt

    // A cause of failure 
    type Failure = 
        | NotImplemented

    // A nice ... ahem ... monadic type to hold everything
    type Result<'a> =
        | Success of 'a
        | Failure of Failure

    // Our function to do the work
    let updateTheThing request value = 
        if value > 5 then
            Failure NotImplemented
        else
            Success (transform request value)

    // Our 'controller' function
    let doWork request = 
        let dbValue = { Key = "userName"; Value = 5 }    
        let response = updateTheThing dbValue request  
        
        match response with
        | Success response -> response.ToString()
        | Failure fail ->
            match fail with
            | NotImplemented -> "Not implemented!"

    


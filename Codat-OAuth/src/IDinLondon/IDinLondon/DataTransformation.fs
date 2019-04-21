namespace IDinLondon

module Dt =

    // Record type
    type InputData = {
        Key: string;
        Value: int
    }

    // Simple data transform
    let transform (input : InputData) newValue = 
        { input with Value = newValue }

    // Testing your code
    let test = 
        let input  = { Key = "test"; Value = 5 }
        let output = { Key = "test"; Value = 8 }
        let result = transform input 8
        result = output
            

    

    




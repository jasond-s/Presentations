namespace IDinLondon

module Inf = 

    open System.Configuration

    open IDinLondon.Dt

    // Some bit of infrastructure we need all the time
    type DatabaseConnection(connectionStringName : string) = 
        let connection = ConfigurationManager.ConnectionStrings.Item(connectionStringName)

        member x.save value = 
            value
                
    // Build some infrastructure
    let saveValueInTheDatabase (connection : DatabaseConnection) value =
        connection.save(value)
            
    let saveValueInMyDatabase value = 
        saveValueInTheDatabase <| DatabaseConnection "MyDatabase"
        

    // No more DI hell! Just type signatures
    let doWork value = 
        transform { Key = "userName"; Value = 3 } value
        |> saveValueInMyDatabase


    // You can even make this stuff easy to test
    let doWorkSuperDuperTestable value saveFn =
        transform { Key = "userName"; Value = 3 } value
        |> saveFn

    let test =  
        let expected = { Key = "userName"; Value = 4 }
        let result = doWorkSuperDuperTestable 4 (fun value -> value)
        expected = result
    
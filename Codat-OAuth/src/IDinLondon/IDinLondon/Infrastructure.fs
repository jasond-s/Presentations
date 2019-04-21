namespace IDinLondon

module Inf = 

    open System.Configuration

    open IDinLondon.Dt

    // Some bit of infrastructure we need all the time, like a SQL DB.
    type DatabaseConnection(connectionStringName : string) = 
        let connection = ConfigurationManager.ConnectionStrings.Item(connectionStringName)
        
        member x.save value =
            printf "\nSAVING %s TO THE DB\n\n" (value.ToString ())
            value
                

    // Build some infrastructure
    let saveValueInTheDatabase (connection : DatabaseConnection) value =
        connection.save(value)
            

    let saveValueInMyDatabase = 
        saveValueInTheDatabase <| DatabaseConnection "MyDatabase"
        

    // No more DI hell! Just type signatures
    let doWork value =
        value
        |> transform { Key = "userName"; Value = 3 }  
        |> saveValueInMyDatabase


    // You can even make this stuff easy to test
    let doWorkSuperDuperTestable saveFn value =
        transform { Key = "userName"; Value = 3 } value
        |> saveFn
        

    // Lets test this!

    let doWorkWithMockSave = doWorkSuperDuperTestable (fun v -> v)
    
    let test =  
        let expected = { Key = "userName"; Value = 4 }
        let result = doWorkWithMockSave 4 
        expected = result
    
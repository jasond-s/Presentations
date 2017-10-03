namespace IDinLondon

module Chl =
    
    type ImpersonalMeasurements = {
        Height : decimal
        HandSize : decimal
        Volume : decimal
    }



    // Units of measure!

    [<Measure>] type meters

    [<Measure>] type area = meters ^ 2

    [<Measure>] type volume = meters ^ 3
    
    let width  = 10M<meters>
    let height = 5M<meters>
    let depth  = 0.5M<meters>
    
    let areaOfSquareThing width height : decimal<area> = 
        width / height

    let volumeOfSquareThing width height depth : decimal<volume> = 
        width * height * depth
    


    // Enrich your domain!

    // Type alias
    type HeightInMeters = decimal<meters>
        
    // Single case unions
    type HandSize = HandSize of decimal<area>

    // Rich types

    //type PersonalMeasurements = {
    //    Height : HeightInMeters
    //    HandSize : HandSize
    //    Volume : decimal<volume>
    //}

    let myHandsize = HandSize (areaOfSquareThing 0.2M<meters> 0.1M<meters>)

    let myVolume = volumeOfSquareThing 1.87M<meters> 0.5M<meters> 0.2M<meters>

    //let myMesaurements = 
    //    { Height = 1.87M<meters>; 
    //      HandSize = myHandsize; 
    //      Volume = myVolume 
    //    }
    
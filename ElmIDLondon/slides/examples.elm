{-
    TYPES ------------------
-}


{-
    This is an alias to a primitive type
-}


type alias Toy = String



{-
    This is a union for some animals
-}

type Animal 
    = Cat
    | Kitten
    | Dog
    | Puppy AnimalName


{-
    They can contain some data as well
-}

type PetActions
    = Stroke
    | Brush
    | Play Toy 



{-
    This is a tuple 
-}

basketOfPuppies = ( Puppy, Puppy )



{-
    This is a record for the owner
-}

type alias Owner = 
    { name : String
    , animalsOwned : List Animal
    }


{-
    Records and unions have constructors
-}

me = Owner "Jason" [ Cat ]




{-
    PURITY ------------------
-}

{-
    1. The type signature tells us what goes in and what goes out.
    2. Every code path must return and you can't do it early.
    3. Case statements are used a lot for 'polymophism'.
-}
petAnimal : Animal -> Animal
petAnimal animal = 
    case animal of 
        Cat -> 
            // Stroke back.
            animal
        Kitten -> 
            // Cuddle gently.
            animal
        Dog -> 
            // Scratch behind ear
            animal
        Puppy ->
            // Wrestle gently
            animal




{-
    IMMUTABILITY ------------------
-}

{-
    1. Can't just edit the list, we need to create a new one.
    2. Can't just edit the owner, we must create a new one.
    3. Luckily, Elm and most FP languages have shortcuts.
        - `{ a | prop = newVal}` short for creating a new one from the old
        - `++` concat, nearly all collection operators return new collections
-}
buyAnotherAnimal : Owner -> Animal -> Owner
buyAnotherAnimal owner animal =
    { owner |
        animalsOwned = owner.animalsOwned ++ [ animal ]
    }



{-
    DECONSTRUCTION ------------------
-}


{-
    Taking a tuple apart.
-}

basketOfKittens = ( Kitten, Kitten, Kitten )

putMyKittensInARow ( sooty, mittens, fluffy ) = 
    sooty::mittens::fluffy::[]

{-
    > type Animal = Kitten | Puppy
    > basketOfKittens = ( Kitten, Kitten, Kitten )
    (Kitten,Kitten,Kitten) : ( Repl.Animal, Repl.Animal, Repl.Animal )
    > putMyKittensInARow (sooty, mittens, fluffy) = sooty::mittens::fluffy::[]
    <function> : ( a, a, a ) -> List a
    > putMyKittensInARow basketOfKittens
    [Kitten,Kitten,Kitten] : List Repl.Animal
-}

{-
    Taking a list apart.
-}

type MaybeAnimal
    = YayAnimals Animal
    | AwwNoAnimals


pickUpTheFirstKitten : List Animal -> MaybeAnimal
pickUpTheFirstKitten kittens = 
    case kittens of 
        first::theRest -> YayAnimals first
        []             -> AwwNoAnimals


goToPetStoreForMoreAnimals : MaybeAnimal -> Owner -> Owner
goToPetStoreForMoreAnimals maybeAnimal owner  = 
    case maybeAnimal of 
        YayAnimals kitty -> 
            { owner | 
                animalsOwned = owner.animalsOwned ++ [kitty] 
            }
        AwwNoAnimals ->
            owner

{-
    This is a maybe monad... shhh... don't tell anyone I said monad.
-}    
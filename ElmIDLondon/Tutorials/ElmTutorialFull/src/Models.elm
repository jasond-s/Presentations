module Models exposing (..)

import Routing
import Players.Models exposing (Player)


type alias Model =
    { players : List Player
    , route : Routing.Route
    }


initialModel : Routing.Route -> Model
initialModel route =
    { players = [ ]
    , route = route
    }
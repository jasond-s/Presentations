module Players.Messages exposing (..)

import Http
import Players.Models exposing (PlayerId, Player)


type Msg
    = FetchAllDone (List Player)
    | FetchAllFail Http.Error
    | ShowPlayers
    | ShowPlayer PlayerId
    | SaveSuccess Player
    | SaveFail Http.Error
    | Increase PlayerId
    | Decreace PlayerId
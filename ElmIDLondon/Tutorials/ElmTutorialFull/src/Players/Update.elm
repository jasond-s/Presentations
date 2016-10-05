module Players.Update exposing (..)

import Navigation

import Players.Messages exposing (Msg(..))
import Players.Commands exposing (save)
import Players.Models exposing (Player, PlayerId)


update : Msg -> List Player -> ( List Player, Cmd Msg )
update message players = 
    case message of 
        FetchAllDone newPlayers -> 
            ( newPlayers, Cmd.none )

        FetchAllFail error ->
            ( players, Cmd.none )

        ShowPlayers ->
            ( players, Navigation.newUrl "#players" )

        ShowPlayer id ->
            ( players, Navigation.newUrl ("#players/" ++ (toString id)) )

        SaveSuccess updatedPlayer ->
            ( updatePlayer updatedPlayer players, Cmd.none )

        SaveFail error ->
            ( players, Cmd.none )

        Increase playerId ->
            ( players, changeLevelCommands playerId 1 players |> Cmd.batch )

        Decreace playerId ->            
            ( players, changeLevelCommands playerId -1 players |> Cmd.batch )


changeLevelCommands : PlayerId -> Int -> List Player -> List (Cmd Msg)
changeLevelCommands playerId howMuch =
    let
        cmdForPlayer existingPlayer =
            if existingPlayer.id == playerId then
                save { existingPlayer | level = existingPlayer.level + howMuch }
            else
                Cmd.none
    in
        List.map cmdForPlayer


updatePlayer : Player -> List Player -> List Player
updatePlayer updatedPlayer =
    let
        select existingPlayer =
            if existingPlayer.id == updatedPlayer.id then
                updatedPlayer
            else
                existingPlayer
    in
        List.map select
module Widget exposing (..)

import Html exposing (Html, button, div, text)
import Html.Events exposing (onClick)


-- MODEL


type alias Model =
    { count : Int
    }


initModel : Model
initModel =
    { count = 0
    }



-- MESSAGES


type Msg
    = Increase
    | Decrease



-- VIEW


view : Model -> Html Msg
view model =
    div []
        [ div [] [ text (toString model.count) ]
        , button [ onClick Increase ] [ text "+" ]
        , button [ onClick Decrease ] [ text "-" ]
        ]



-- UPDATE


update : Msg -> Model -> ( Model, Cmd Msg )
update message model =
    case message of
        Increase ->
            ( { model | count = model.count + 1 }, Cmd.none )
        Decrease ->
            ( { model | count = model.count - 1 }, Cmd.none )
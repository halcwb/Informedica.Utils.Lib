﻿namespace Informedica.GenUtils.Lib

module Array =

    open Informedica.GenUtils.Lib.BCL

    let pickArray pl xs =
        match xs with
        | [||] -> xs
        | _ -> 
            [| for i in pl -> xs |> Array.item i |]


    let arrayFilter p xs =
        xs
        |> Array.filter (fun r -> 
            r |> Array.exists (fun x -> p x )) 


    let collectArrays p xs =
        xs
        |> Array.collect (fun r -> 
            r
            |> Array.filter (fun x -> p x))


    let inline toString xs =
        match xs with
        | [||] -> "[||]"
        | _ ->
            let s =
                xs 
                |> Array.fold (fun s x -> s + (string) x + ";") "[|"
            (s
            |> String.subString 0 ((s |> String.length) - 1)) + "|]"
    

    let allEqual succ fail xs =
        if xs   |> Array.length = 0 then fail
        elif xs |> Array.length = 1 then succ xs.[0]
        else
            let x = xs.[0]
            if xs |> Array.forall ((=) x) then succ x 
            else fail


    let allEqualToString xs = xs |> allEqual string ""


    let allEqualToOpt xs = xs |> allEqual Some None

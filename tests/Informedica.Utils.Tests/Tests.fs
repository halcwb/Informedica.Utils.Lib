﻿module Tests

    open Expecto

    [<Tests>]
    let test =
        testCase "Hello World" <| fun _ ->
            Expect.isTrue true "This is true"


    module String =

        open Expecto

        open Informedica.GenUtils.Lib.BCL

        [<Tests>]
        let tests =

            let equals exp txt res = Expect.equal res exp txt

            testList "String" [

                test "splitAt can split a string at character " {
                    Expect.equal ("Hello World" |> String.splitAt ' ')  [|"Hello"; "World"|] " space "
                }

                test "splitAt split of null will yield "  {
                    null
                    |> String.splitAt ' '
                    |> equals [||] " empty array "
                }

                test "splitAt split of an empty string will yield " {
                    ""
                    |> String.splitAt 'a'
                    |> equals [|""|] "an array with an empty string"
                }

                test "split split ca split a string with a string" {
                    "Hello_world"
                    |> String.split "_"
                    |> equals ["Hello"; "world"] "into a list of two strings"
                }

                test "split with a null will yield" {
                    null
                    |> String.split ""
                    |> equals [] "an empty list"
                }

                test "capitalize of an empty string" {
                    ""
                    |> String.capitalize
                    |> equals "" "returns an empty string"
                }

                test "capitalize of an null string" {
                    null
                    |> String.capitalize
                    |> equals "" "returns an empty string"
                }    

                test "capitalize of hello world" {
                    "hello world"
                    |> String.capitalize
                    |> equals "Hello world" "returns an empty string"
                }

                test "contains null string null string" {
                    null
                    |> String.contains null
                    |> equals false "returns false"
                }

                test "contains empty string null string" {
                    ""
                    |> String.contains null
                    |> equals false "returns false"
                }

                test "contains null string empty string" {
                    null
                    |> String.contains ""
                    |> equals false "returns false"
                }

                test "contains abc string null string" {
                    "abc"
                    |> String.contains null
                    |> equals false "returns false"
                }

                test "contains abc string empty string" {
                    "abc"
                    |> String.contains ""
                    |> equals true "returns true"
                }

                test "contains abc string a string" {
                    "abc"
                    |> String.contains "a"
                    |> equals true "returns true"
                }

                test "contains abc string b string" {
                    "abc"
                    |> String.contains "b"
                    |> equals true "returns true"
                }

                test "contains abc string c string" {
                    "abc"
                    |> String.contains "c"
                    |> equals true "returns true"
                }

                test "contains abc string abcd string" {
                    "abc"
                    |> String.contains "abcd"
                    |> equals false "returns false"
                }

                test "equals null string null string" {
                    null
                    |> String.equals null
                    |> equals true "returns true"
                }

                test "equals null string empty string" {
                    null
                    |> String.equals ""
                    |> equals false "returns false"
                }

                test "equals a string A string" {
                    "a"
                    |> String.equals "A"
                    |> equals false "returns false"
                }

                test "equalsCapsInsens a string A string" {
                    "a"
                    |> String.equalsCapInsens "A"
                    |> equals true "returns true"
                }

                test "subString of a null string will yield" {
                    null
                    |> String.subString 0 1
                    |> equals "" "returns an empty string"
                }    

                test "subString of an empty string will yield" {
                    ""
                    |> String.subString 0 1
                    |> equals "" "returns an empty string"
                }    

                test "subString 0 1 of abc string will yield" {
                    "abc"
                    |> String.subString 0 1
                    |> equals "a" "returns a"
                }

                test "subString 1 1 of abc string will yield" {
                    "abc"
                    |> String.subString 1 1
                    |> equals "b" "returns b"
                }

                test "subString 0 0 of abc string will yield" {
                    "abc"
                    |> String.subString 0 0
                    |> equals "" "returns an empty string"
                }

                test "subString 1 -1 of abc string will yield" {
                    "abc"
                    |> String.subString 1 -1
                    |> equals "a" "returns an a"
                }

                test "subString 1 -2 of abc string will yield" {
                    "abc"
                    |> String.subString 1 -2
                    |> equals "" "returns an empty string"
                }

                test "startsWith null string with null string" {
                    null
                    |> String.startsWith null
                    |> equals false "returns false"
                }

                test "startsWith null string with empty string" {
                    null
                    |> String.startsWith ""
                    |> equals false "returns false"
                }

                test "startsWith empty string with null string" {
                    ""
                    |> String.startsWith null
                    |> equals false "returns false"
                }

                test "startsWith abc string with a string" {
                    "abc"
                    |> String.startsWith "a"
                    |> equals true "returns true"
                }

                test "startsWith abc string with abc string" {
                    "abc"
                    |> String.startsWith "abc"
                    |> equals true "returns true"
                }

                test "startsWith abc string with abcd string" {
                    "abc"
                    |> String.startsWith "abcd"
                    |> equals false "returns false"
                }

                test "startsWith abc string with A string" {
                    "abc"
                    |> String.startsWith "A"
                    |> equals false "returns false"
                }

                test "startsWithCapsInsens abc string with A string" {
                    "abc"
                    |> String.startsWithCapsInsens "A"
                    |> equals true "returns true"
                }

                test "restString of null string" {
                    null
                    |> String.restString
                    |> equals "" "returns empty string"
                }

                test "restString of empty string" {
                    ""
                    |> String.restString
                    |> equals "" "returns empty string"
                }

                test "restString of a string" {
                    "a"
                    |> String.restString
                    |> equals "" "returns empty string"
                }

                test "restString of abc string" {
                    "abc"
                    |> String.restString
                    |> equals "bc" "returns bc string"
                }

            ]


    module Double =

        open System
        open Expecto
        open MathNet.Numerics

        open Informedica.GenUtils.Lib.BCL

        [<Tests>]
        let tests =

            let equals exp txt res = Expect.equal res exp txt

            let config = 
                { FsCheckConfig.defaultConfig with 
                    maxTest = 10000 }

            testList "Double" [

                testPropertyWithConfig config "any valid string double can be parsed to a double" <| fun (a: Double) ->
                    if a |> Double.isValid |> not then true
                    else
                        a
                        |> string
                        |> Double.parse
                        |> string
                        |> ((=) (string a))

                testPropertyWithConfig config "any string can be used to try parse" <| fun s ->
                    s
                    |> Double.tryParse
                    |> (fun _ -> true)

                testPropertyWithConfig config "getPrecision can be calculated for any valid double" <| fun (a: Double) n ->
                    if a |> Double.isValid |> not then true
                    else
                        a
                        |> Double.getPrecision n
                        |> (fun _ -> true)

                testPropertyWithConfig config "getPrecision for a abs value < 0 never returns a smaller value than precision (> 0)" <| fun (a: Double) n ->
                    if n <= 0 || a |> Double.isValid |> not then true
                    else
                        a
                        |> Double.getPrecision n
                        |> (fun x -> 
                            if a |> abs < 0. && x < n then
                                printfn "decimals %i < precision %i for value %f" x n a
                                false
                            else true
                        )

                testPropertyWithConfig config "getPrecision for every precision < 0 returns same as n = 0" <| fun (a: Double) n ->
                    if a |> Double.isValid |> not then true
                    else
                        a
                        |> Double.getPrecision n
                        |> (fun x -> 
                            if n < 0 then
                                x = (a |> Double.getPrecision 0)
                            else true
                        )

                // * 66.666 |> Double.getPrecision 1 = 0
                test "66.666 |> Double.getPrecision 1 = 0" {
                    66.666 |> Double.getPrecision 1 
                    |> equals 0 ""            
                }

                // * 6.6666 |> Double.getPrecision 1 = 0
                test "6.6666 |> Double.getPrecision 1 = 0" {
                    6.6666 |> Double.getPrecision 1 
                    |> equals 0 ""            
                }

                // * 0.6666 |> Double.getPrecision 1 = 1
                test "6.6666 |> Double.getPrecision 1 = 1" {
                    0.6666 |> Double.getPrecision 1 
                    |> equals 1 ""            
                }

                // * 0.0666 |> Double.getPrecision 1 = 2
                test "0.0666 |> Double.getPrecision 1 = 2" {
                    0.0666 |> Double.getPrecision 1
                    |> equals 2 ""            
                }

                // * 0.0666 |> Double.getPrecision 0 = 0
                test "0.0666 |> Double.getPrecision 0 = 0" {
                    0.0666 |> Double.getPrecision 0
                    |> equals 0 ""            
                }

                // * 0.0666 |> Double.getPrecision 2 = 3
                test "0.0666 |> Double.getPrecision 2 = 3" {
                    0.0666 |> Double.getPrecision 2
                    |> equals 3 ""            
                }

                // * 0.0666 |> Double.getPrecision 3 = 4
                test "0.0666 |> Double.getPrecision 3 = 4" {
                    0.0666 |> Double.getPrecision 3
                    |> equals 4 ""            
                }

                // * 6.6666 |> Double.getPrecision 0 = 0
                test "6.6666 |> Double.getPrecision 0 = 0" {
                    6.6666 |> Double.getPrecision 0
                    |> equals 0 ""            
                }

                // * 6.6666 |> Double.getPrecision 2 = 1
                test "6.6666 |> Double.getPrecision 2 = 1" {
                    6.6666 |> Double.getPrecision 2
                    |> equals 1 ""            
                }

                // * 6.6666 |> Double.getPrecision 3 = 2
                test "6.6666 |> Double.getPrecision 3 = 2" {
                    6.6666 |> Double.getPrecision 3
                    |> equals 2 ""            
                }


                // * 66.666 |> Double.fixPrecision 1 = 67
                test "66.666 |> Double.fixPrecision 1 = 67" {
                    66.666 |> Double.fixPrecision 1 
                    |> equals 67. ""            
                }

                // * 6.6666 |> Double.fixPrecision 1 = 7
                test "6.6666 |> Double.fixPrecision 1 = 7" {
                    6.6666 |> Double.fixPrecision 1 
                    |> equals 7. ""            
                }

                // * 0.6666 |> Double.fixPrecision 1 = 0.7
                test "6.6666 |> Double.fixPrecision 1 = 0.7" {
                    0.6666 |> Double.fixPrecision 1 
                    |> equals 0.7 ""            
                }

                // * 0.0666 |> Double.fixPrecision 1 = 0.07
                test "0.0666 |> Double.fixPrecision 1 = 0.07" {
                    0.0666 |> Double.fixPrecision 1
                    |> equals 0.07 ""            
                }

                // * 0.0666 |> Double.fixPrecision 0 = 0
                test "0.0666 |> Double.fixPrecision 0 = 0" {
                    0.0666 |> Double.fixPrecision 0
                    |> equals 0. ""            
                }

                // * 0.0666 |> Double.fixPrecision 2 = 0.067
                test "0.0666 |> Double.fixPrecision 2 = 0.067" {
                    0.0666 |> Double.fixPrecision 2
                    |> equals 0.067 ""            
                }

                // * 0.0666 |> Double.fixPrecision 3 = 0.0666
                test "0.0666 |> Double.fixPrecision 3 = 0.0666" {
                    0.0666 |> Double.fixPrecision 3
                    |> equals 0.0666 ""            
                }

                // * 6.6666 |> Double.fixPrecision 0 = 7
                test "6.6666 |> Double.fixPrecision 0 = 7" {
                    6.6666 |> Double.fixPrecision 0
                    |> equals 7. ""            
                }

                // * 6.6666 |> Double.fixPrecision 2 = 6.7
                test "6.6666 |> Double.fixPrecision 2 = 6.7" {
                    6.6666 |> Double.fixPrecision 2
                    |> equals 6.7 ""            
                }

                // * 6.6666 |> Double.fixPrecision 3 = 6.67
                test "6.6666 |> Double.fixPrecision 3 = 6.67" {
                    6.6666 |> Double.fixPrecision 3
                    |> equals 6.67 ""            
                }

                testPropertyWithConfig config "for any valid float, this float can be converted to a fraction" <| fun f ->
                    if f |> Double.isValid |> not then true
                    else
                        f
                        |> Double.floatToFract
                        |> (fun r ->
                            match r with
                            | None -> true
                            | Some (n, d) -> 
                                ((n |> BigRational.FromBigInt) / (d |> BigRational.FromBigInt))
                                |> ((=) (f |> BigRational.fromFloat |> Option.get))
                        )

            ]


    module BigRational =


        open Expecto

        open MathNet.Numerics
        open Informedica.GenUtils.Lib.BCL


        /// Create the necessary test generators
        module Generators =

            open FsCheck

            let bigRGen (n, d) = 
                    let d = if d = 0 then 1 else d
                    let n' = abs(n) |> BigRational.FromInt
                    let d' = abs(d) |> BigRational.FromInt
                    n'/d'

            let bigRGenerator =
                gen {
                    let! n = Arb.generate<int>
                    let! d = Arb.generate<int>
                    return bigRGen(n, d)
                }

            type MyGenerators () =
                static member BigRational () =
                    { new Arbitrary<BigRational>() with
                        override x.Generator = bigRGenerator }


        [<Tests>]
        let tests =

            let equals exp txt res = Expect.equal res exp txt

            let config = 
                { FsCheckConfig.defaultConfig with 
                    maxTest = 10000
                    arbitrary = [ typeof<Generators.MyGenerators> ] }

            let opMult f () = f (*)

            testList "BigRational" [

                test "can parse a string number 1" {
                    "1"
                    |> BigRational.tryParse
                    |> equals (Some 1N) "to a br 1"
                }

                testPropertyWithConfig config "can try to convert any double to bigrational" <| fun (a: float) ->
                    a 
                    |> (BigRational.fromFloat >> Option.defaultValue 0N >> BigRational.toFloat) 
                    |> (fun b -> 
                        if b = 0. || Accuracy.areClose Accuracy.veryHigh a b then true
                        else
                            printfn "%f <> %f" a b
                            false
                    )


                testPropertyWithConfig config "can convert any bigrational to a double" <| fun br ->
                    let f = 
                        br 
                        |> BigRational.toFloat
                    f
                    |> BigRational.fromFloat 
                    |> (fun r -> 
                        if r |> Option.isNone then false
                        else
                            r
                            |> Option.get
                            |> BigRational.toFloat
                            |> Accuracy.areClose Accuracy.veryHigh f
                    )

                testPropertyWithConfig config "can parse any string float" <| fun (a: float) ->
                    match a |> (BigRational.fromFloat >> Option.defaultValue 0N >> string >> BigRational.tryParse) with
                    | Some b -> 
                        b
                        |> BigRational.toString 
                        |> BigRational.parse = b
                    | None -> true

                testPropertyWithConfig config "parse can be reversed" <| fun a ->
                    match a |> BigRational.tryParse with
                    | Some b -> 
                        b 
                        |> BigRational.toString 
                        |> BigRational.parse = b
                    | None -> true

                testPropertyWithConfig config "when a is gcd of b and c then b and c both are a multiple of a" <| fun b c ->
                    // printfn "%s %s %s" (b |> BigRational.toString) (c |> BigRational.toString) (a |> BigRational.toString)
                    if (b = 0N || c = 0N) then true
                    else
                        let a = BigRational.gcd b c
                        b |> BigRational.isMultiple a && 
                        c |> BigRational.isMultiple a


                testPropertyWithConfig config "when b is converted to multiple of c then result a is multiple of c" <| fun b c ->
                    // printfn "%s %s %s" (b |> BigRational.toString) (c |> BigRational.toString) (a |> BigRational.toString)
                    if (b = 0N || c = 0N) then true
                    else
                        let a = b |> BigRational.toMultipleOf c
                        a |> BigRational.isMultiple c 

                testPropertyWithConfig config "can check is multiple for any bigrational" <| fun b c ->
                    if c = 0N then b |> BigRational.isMultiple c |> not
                    else
                        if b |> BigRational.isMultiple c then (b / c).Denominator = 1I
                        else (b / c).Denominator <> 1I 

                test "when operator is multiplication" {
                    Expect.equal ((*) |> BigRational.opIsMult) true ""
                }

                test "when operator is addition" {
                    Expect.equal ((+) |> BigRational.opIsAdd) true ""
                }

                test "when operator is division" {
                    Expect.equal ((/) |> BigRational.opIsDiv) true ""
                }

                test "when operator is subtraction" {
                    Expect.equal ((-) |> BigRational.opIsSubtr) true ""
                }

            ]


    module List =

        open Expecto

        open Informedica.GenUtils.Lib

        [<Tests>]
        let tests =

            let equals exp txt res = Expect.equal res exp txt

            testList "List" [

                test "replace an element in an empty list " {
                    []
                    |> List.replace ((=) "a") ""
                    |> equals [] "returns an empty list"
                }

                test "replace an element in a list with the element " {
                    ["a"]
                    |> List.replace ((=) "a") "b"
                    |> equals ["b"] "returns the list with the first match replaced"
                }

                test "replace an element in a list without the element " {
                    ["a"]
                    |> List.replace ((=) "b") ""
                    |> equals ["a"] "returns the list with the first match replaced"
                }

                test "replace an element in a list with multiple elements " {
                    ["a";"b";"a"]
                    |> List.replace ((=) "a") "b"
                    |> equals ["b";"b";"a"] "returns the list with the first match replaced"
                }


            ]


    module Reflection =

        open Expecto

        open Informedica.GenUtils.Lib

        type TestUnion = TestUnion | AnotherTestUnion

        [<Tests>]
        let tests =

          testList "Reflection toString and fromString " [

            testCase "of discriminate union TestUnion" <| fun _ ->
              Expect.equal (TestUnion |> Reflection.toString) "TestUnion" "should print TestUnion"
     
            test "of discriminate union AnotherTestUnion" {
              Expect.equal (AnotherTestUnion |> Reflection.toString) "AnotherTestUnion" "should print AnotherTestUnion"
            }

            test "can create a TestUnion Option" {
                Expect.equal ("TestUnion" |> Reflection.fromString<TestUnion>) (Some TestUnion) "from string TestUnion"
            }

            test "will return None with a non existing union type" {
                Expect.equal ("blah" |> Reflection.fromString<TestUnion>) None "from string blah"
            }
 
          ]

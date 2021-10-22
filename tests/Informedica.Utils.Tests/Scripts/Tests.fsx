//#I __SOURCE_DIRECTORY__

#r "nuget: MathNet.Numerics.FSharp"
#r "nuget: Expecto"
#r "nuget: Expecto.FsCheck"

#load "../../../src/Informedica.Utils.Lib/Scripts/load.fsx"
#load "../Tests.fs"

open System
open Expecto
open Expecto.Flip
open Expecto.Logging

Tests.BigRational.tests
|> runTestsWithCLIArgs [ CLIArguments.Verbosity LogLevel.Verbose; CLIArguments.Sequenced ] [||]

Tests.Double.tests
|> runTestsWithCLIArgs [ CLIArguments.Verbosity LogLevel.Verbose; CLIArguments.Sequenced ] [||]

Tests.List.tests
|> runTestsWithCLIArgs [ CLIArguments.Verbosity LogLevel.Verbose; CLIArguments.Sequenced ] [||]

Tests.Reflection.tests
|> runTestsWithCLIArgs [ CLIArguments.Verbosity LogLevel.Verbose; CLIArguments.Sequenced ] [||]

Tests.String.tests
|> runTestsWithCLIArgs [ CLIArguments.Verbosity LogLevel.Verbose; CLIArguments.Sequenced ] [||]


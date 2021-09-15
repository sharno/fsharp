// Copyright (c) Microsoft Corporation.  All Rights Reserved.  See License.txt in the project root for license information.

namespace Microsoft.FSharp.Core

    open Microsoft.FSharp.Core.LanguagePrimitives.IntrinsicOperators

    [<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    /// <summary>Contains operations for working with values of type <see cref="T:Microsoft.FSharp.Core.Result`2"/>.</summary>
    ///
    /// <category>Choices and Results</category>
    module Result =

        /// <summary><c>map f inp</c> evaluates to <c>match inp with Error e -> Error e | Ok x -> Ok (f x)</c>.</summary>
        /// <param name="mapping">A function to apply to the OK result value.</param>
        /// <param name="result">The input result.</param>
        ///
        /// <returns>A result of the input value after applying the mapping function, or Error if the input is Error.</returns>
        ///
        /// <example>
        /// <code lang="fsharp">
        ///     Ok 1            |> map (fun x -> "perfect") = Ok "perfect"
        ///     Error "message" |> map (fun x -> "perfect") = Error "message"
        /// </code>
        /// </example>
        [<CompiledName("Map")>]
        val map : mapping:('T -> 'U) -> result:Result<'T, 'TError> -> Result<'U, 'TError>

        /// <summary><c>map f inp</c> evaluates to <c>match inp with Error x -> Error (f x) | Ok v -> Ok v</c>.</summary>
        ///
        /// <param name="mapping">A function to apply to the Error result value.</param>
        /// <param name="result">The input result.</param>
        ///
        /// <returns>A result of the error value after applying the mapping function, or Ok if the input is Ok.</returns>
        ///
        /// <example>
        /// <code lang="fsharp">
        ///     Ok 1        |> mapError (fun x -> "bar") = Ok 1
        ///     Error "foo" |> mapError (fun x -> "bar") = Error "bar"
        /// </code>
        /// </example>
        [<CompiledName("MapError")>]
        val mapError: mapping:('TError -> 'U) -> result:Result<'T, 'TError> -> Result<'T, 'U>

        /// <summary><c>bind f inp</c> evaluates to <c>match inp with Error e -> Error e | Ok x -> f x</c></summary>
        ///
        /// <param name="binder">A function that takes the value of type T from a result and transforms it into
        /// a result containing a value of type U.</param>
        /// <param name="result">The input result.</param>
        ///
        /// <returns>A result of the output type of the binder.</returns>
        ///
        /// <example>
        /// <code lang="fsharp">
        ///     let tryParse (input: string) =
        ///         match System.Int32.TryParse input with
        ///         | true, v -> Ok v
        ///         | false, _ -> Error "couldn't parse"
        ///     
        ///     Error "message" |> bind tryParse = Error "message"
        ///     Ok "42"         |> bind tryParse = Ok 42
        ///     Ok "Forty-two"  |> bind tryParse = Error "couldn't parse"
        /// </code>
        /// </example>
        [<CompiledName("Bind")>]
        val bind: binder:('T -> Result<'U, 'TError>) -> result:Result<'T, 'TError> -> Result<'U, 'TError>

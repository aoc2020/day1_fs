// Learn more about F# at http://fsharp.org

open System
open System.IO

let readLines (filePath: String) = seq {
    use sr = new StreamReader (filePath)
    while not sr.EndOfStream do
        yield sr.ReadLine ()
}

let readInts (filePath: String) = 
    let lines = readLines(filePath)
    lines |> Seq.map(Int64.Parse) |> Seq.toArray

let rec findMul sum (values: Int64[]) =
    if Array.length values < 2
    then 0L
    else (
        let value = values.[0]
        let other = sum - value
        let rest = values.[1..]
        if Array.contains other rest then
            value * other
        else
            findMul sum rest
        )
let findMul2 = findMul 2020L

let rec findMul3 (values: Int64[]) =
    let value = values.[0]
    let others = 2020L - value
    let rest = values.[1..]
    let result = findMul others rest
    if result > 0L
    then result * value
    else findMul3 rest
    
let solutionText num value =
    match value with
    | Some(i) -> String.Format ("Solution {0} {0}",num,i)
    | None -> "No solution found"

[<EntryPoint>]
let main argv =
    let home = System.Environment.GetEnvironmentVariable "HOME"
    printfn "home = %s" home
    printfn "Hello World from F#!"
    let values = readInts("/Users/xeno/projects/aoc2020/day1_fs/input.txt")
    let sol1 = findMul2 values
    printfn "Solution 1: %d" sol1
    let sol2 = findMul3 values
    printfn "Solution 2: %d" sol2
    0 // return an integer exit code
namespace ProjectEuler

module Helpers = 
    let isPrime n = 
        if n < 2L then false
        else 
            seq { 2L..int64 (System.Math.Sqrt(float n)) }
            |> Seq.exists (fun x -> (n % x = 0L) || n % (x + 2L) = 0L)
            |> not
    
    let isFactor (candidate : int64) n = (n % candidate) = 0L
    let isEven n = (n % 2 = 0)
    let isOdd n = (n % 2 <> 0)

﻿namespace ProjectEuler

module Helpers = 
    let isPrime n = 
        seq { 2L..int64 (System.Math.Sqrt(float n)) }
        |> Seq.exists (fun x -> (n % x = 0L) || n % (x + 2L) = 0L)
        |> not
    
    let isFactor (candidate : int64) n = (n % candidate) = 0L
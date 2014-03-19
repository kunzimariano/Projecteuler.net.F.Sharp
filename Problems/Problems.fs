﻿namespace ProjectEuler

module Problem1 = 
    //Multiples of 3 and 5
    //If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    //Find the sum of all the multiples of 3 or 5 below 1000.
    let printResult() = 
        let sumOfMultiples = 
            seq { 1..999 }
            |> Seq.filter (fun x -> (x % 3) = 0 || (x % 5) = 0)
            |> Seq.reduce (fun x y -> x + y)

        printf "result is: %d" sumOfMultiples
        ()

module Problem2 = 
    //Even Fibonacci numbers
    //Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:
    //1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
    //By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.       
    let printResult() = 
        let fibonacci = Seq.unfold (fun (current, next) -> Some(current, (next, current + next))) (0, 1)
        
        let result = 
            fibonacci
            |> Seq.takeWhile (fun n -> n < 4000000)
            |> Seq.filter (fun x -> (x % 2) = 0)
            |> Seq.reduce (fun x y -> x + y)
        printf "result is: %d" result
        ()

module Problem3 = 
    //The prime factors of 13195 are 5, 7, 13 and 29.
    //What is the largest prime factor of the number 600851475143 ?
    let printResult() = 
        let n = 600851475143L
        
        let result = 
            seq { 2L..int64 (System.Math.Sqrt(float n)) }
            |> Seq.filter (fun x -> (Helpers.isFactor x n) && Helpers.isPrime x)
            |> Seq.last
        printf "result is: %d" result
        ()
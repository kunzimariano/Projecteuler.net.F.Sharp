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
            |> Seq.filter (fun x -> Helpers.isEven x)
            |> Seq.reduce (fun x y -> x + y)
        printf "result is: %d" result

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

module Problem4 = 
    //A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
    //Find the largest palindrome made from the product of two 3-digit numbers.
    let printResult() = 
        let isPalindrome (number : string) = new string(number.ToCharArray() |> Array.rev) = number
        
        let result = 
            seq { 
                for i in 100..999 do
                    for j in 100..999 do
                        yield (i * j)
            }
            |> Seq.where (fun x -> isPalindrome (string x))
            |> Seq.max
        printf "result is: %d" result

module Problem5 = 
    //2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
    //What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
    let printResult() = 
        let isDivisible n = 
            seq { 20..-1..11 }
            |> Seq.exists (fun x -> n % x <> 0)
            |> not
        
        let result = seq { 20..2..300000000 } |> Seq.find (fun x -> (isDivisible x))
        printf "result is: %d" result

module Problem6 = 
    //The sum of the squares of the first ten natural numbers is, 1^2 + 2^2 + ... + 10^2 = 385
    //The square of the sum of the first ten natural numbers is, (1 + 2 + ... + 10)^2 = 55^2 = 3025
    //Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
    //Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
    let printResult() = 
        let sumOfSquares = 
            [ 1.0..100.0 ]
            |> Seq.map (fun x -> x * x)
            |> Seq.fold (+) 0.0        
        
        let squareOfSums = ([ 1.0..100.0 ] |> Seq.fold (+) 0.0) ** 2.0

        printf "result is: %A" ( squareOfSums - sumOfSquares)

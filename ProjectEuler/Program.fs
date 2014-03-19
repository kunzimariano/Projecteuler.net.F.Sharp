namespace ProjectEuler

module Program = 
    [<EntryPoint>]
    let main args = 
        let r = Problems.Problem1.sumOfMultiples
        printf "result is: %d" r
        let input = System.Console.Read()
        0

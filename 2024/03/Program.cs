using System.Text.RegularExpressions;

string corruptedMemory = File.ReadAllText("input.txt");

// Part 1
var partOneTotal  = Regex.Matches(corruptedMemory, @"mul\(\d{1,3},\d{1,3}\)")
                .Select(m => m.Value)
                .Select(m => 
                    m.Replace("mul(", "")
                        .Replace(")", "")
                        .Split(",")
                        .Select(x => int.Parse(x))
                        .Aggregate((a, x) => a * x)).Sum();

Console.WriteLine($"Part 1 Result: {partOneTotal}");
var matches = Regex.Matches(corruptedMemory, @"(mul\(\d{1,3},\d{1,3}\))|(don't\(\))|(do\(\))");

// Part 2
bool calc = true;
int partTwoTotal = 0;
foreach(var match in matches.Select(x => x.Value))
{
    switch(match)
    {
        case "don't()":
            calc = false;
            continue;
        case "do()":
            calc = true;
            continue;
    }

    if (calc)
    {
        partTwoTotal += match.Replace("mul(", "")
         .Replace(")", "")
         .Split(",")
        .Select(x => int.Parse(x))
        .Aggregate((a, x) => a * x);
    }
}

Console.WriteLine($"Part 2 Result: {partTwoTotal}");
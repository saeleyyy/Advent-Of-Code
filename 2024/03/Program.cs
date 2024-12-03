using System.Text.RegularExpressions;

string corruptedMemory = File.ReadAllText("input.txt");

var total  = Regex.Matches(corruptedMemory, @"mul\(\d{1,3},\d{1,3}\)")
                .Select(m => m.Value)
                .Select(m => 
                    m.Replace("mul(", "")
                        .Replace(")", "")
                        .Split(",")
                        .Select(x => int.Parse(x))
                        .Aggregate((a, x) => a * x)).Sum();

Console.WriteLine($"Part 1 Result: {total}");
var x = Regex.Matches(corruptedMemory, @"(mul\(\d{1,3},\d{1,3}\))|(don't\(\))|(do\(\))");

bool calc = true;
List<string> y = new();
foreach(var t  in x.Select(x => x.Value))
{
    if(t == "don't()")
    {
        calc = false;
        continue;
    }

    if(t == "do()") {
        calc = true;
        continue;
    };

    if(calc == true)
    {
        y.Add(t);
    }
}

var res = y.Select(m => 
    m.Replace("mul(", "")
    .Replace(")", "")
    .Split(",")
    .Select(x => int.Parse(x))
    .Aggregate((a, x) => a * x)).Sum();

Console.WriteLine($"Part 2 Result: {res}");
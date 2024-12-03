using System.Text.RegularExpressions;

string corruptedMemory = File.ReadAllText("input.txt");

// Step 1: Get all valid blocks of mul calculations
string regexPattern = @"mul\(\d{1,3},\d{1,3}\)";

var matches = Regex.Matches(corruptedMemory, regexPattern).Select(m => m.Value);

// Step 2: Parse out expressions from each match
var total  = matches
    .Select(m => m.Replace("mul(", "").Replace(")", "").Split(",").Select(x => int.Parse(x)).Aggregate((a, x) => a * x)).Sum();

Console.WriteLine($"Result: {total}");
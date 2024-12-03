using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

// string corruptedMemory = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";

string corruptedMemory = File.ReadAllText("input.txt");

// Step 1: Get all valid blocks of mul calculations
string regexPattern = @"mul\(\d{1,3},\d{1,3}\)";

var matches = Regex.Matches(corruptedMemory, regexPattern).Select(m => m.Value);

// Step 2: Parse out expressions from each match
var total  = matches
    .Select(m => m.Replace("mul(", "").Replace(")", "").Split(",").Select(x => int.Parse(x)).Aggregate((a, x) => a * x)).Sum();

Console.WriteLine($"Result: {total}");
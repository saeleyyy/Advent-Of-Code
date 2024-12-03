using System.Text.RegularExpressions;

var total  = Regex.Matches(File.ReadAllText("input.txt"), @"mul\(\d{1,3},\d{1,3}\)")
                .Select(m => m.Value)
                .Select(m => 
                    m.Replace("mul(", "")
                        .Replace(")", "")
                        .Split(",")
                        .Select(x => int.Parse(x))
                        .Aggregate((a, x) => a * x)).Sum();

Console.WriteLine($"Result: {total}");
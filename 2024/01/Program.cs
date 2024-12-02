internal class Program
{
    private static readonly List<int> locationIdsLeft = new();
    private static readonly List<int> locationIdsRight = new();

    private static void Main(string[] args)
    {

        // Part 1
        // // Step 1: Parse file into two lists (is there a better way of doing this?)
        // foreach(var line in File.ReadLines("input.txt"))
        // {
        //     var split = line.Split("   ");

        //     locationIdsLeft.Add(int.Parse(split[0]));
        //     locationIdsRight.Add(int.Parse(split[1]));
        // }

        // // Step 2: Sort the list by ascending order
        // locationIdsLeft.Sort();
        // locationIdsRight.Sort();

        // List<int> distances = new();
        // // Setp 3: Find the distnace between numbers with the same index in each list
        // foreach (var (left, right) in locationIdsLeft.Zip(locationIdsRight))
        // {
        //     distances.Add(Math.Abs(left - right));
        // }

        // // Step 4: Add all of them together
        // int result = 0;
        // foreach (var distance in distances)
        // {
        //     result += distance;
        // }

        // // Correct Result - 2742123
        // Console.WriteLine(result);

        // Part 2:

        foreach(var line in File.ReadLines("input.txt"))
        {
            var split = line.Split("   ");

            locationIdsLeft.Add(int.Parse(split[0]));
            locationIdsRight.Add(int.Parse(split[1]));
        }

        // Step 2: Get similarity scores
        List<int> scores = new();
        foreach(var leftItem in locationIdsLeft)
        {
            int appearances = 0;
            // How many times does it appear in the right
            foreach(var rightItem in locationIdsRight)
            {
                if (leftItem == rightItem)
                {
                    appearances++;
                }
            }
            scores.Add(leftItem * appearances);
        }

        // Step 3: Get total simlarity score
        int final = 0;
        foreach (var score in scores)
        {
            final += score;
        }

        Console.WriteLine(final);
    }
}
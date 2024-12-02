internal class Program
{
    private static int totalSafe { get; set; } = 0;
    private static int totalUnsafe { get; set; } = 0;
    private static int linesProcessed { get; set; } = 0;
    private static List<int[]> unsafeReports = new();
    
    private static void Main(string[] args)
    {
        // Part One
        IdentifySafeReports();
        // Part Two
        DampenUnsafeReports();
    }
    
    private static void IdentifySafeReports()
    {
        foreach(var report in File.ReadLines("input.txt"))
        {
            linesProcessed++;

            // Parse levels into int array
            var levels = report.Split(" ").Select(int.Parse).ToArray();

            // Determine expected trajectory of report levels to be determined safe
            LevelTrajectory expectedTrajectory = levels[0] > levels[1] ? LevelTrajectory.Descending : LevelTrajectory.Ascending;

            bool safe = true;
            foreach (var (curr, next) in levels.Zip(levels.Skip(1)))
            {
                var trajectory = curr > next ? LevelTrajectory.Descending : LevelTrajectory.Ascending;

                /*
                    Mark report as unsafe if current and next level...
                        are the same value
                        have a difference of outside the range 1 -> 3
                        change trajectory i.e. 1, 2, 3, 5. Changes to Ascending at 5
                        
                */
                if (curr == next || Math.Abs(curr - next) > 3 || trajectory != expectedTrajectory)
                {
                    totalUnsafe++;
                    unsafeReports.Add(levels);
                    safe = false;
                    break;
                }
            }

            if (safe)
            {
                totalSafe++;
            }
        }

        Console.WriteLine($"\nTotal Safe Reports: {totalSafe}");
        Console.WriteLine($"Total UnSafe Reports: {totalUnsafe}");
        Console.WriteLine($"Lines Processed: {linesProcessed}");
    }

    private static void DampenUnsafeReports()
    {
        int newlySafeReports = 0;
        int counter = 0;
        foreach (var report in unsafeReports)
        {
            counter++;
            for (int i = 0; i < report.Count(); i++)
            {
                var levels = report.ToList();
                levels.RemoveAt(i);

                LevelTrajectory expectedTrajectory = levels[0] > levels[1] ? LevelTrajectory.Descending : LevelTrajectory.Ascending;

                bool safe = true;
                foreach (var (curr, next) in levels.Zip(levels.Skip(1)))
                {
                    var trajectory = curr > next ? LevelTrajectory.Descending : LevelTrajectory.Ascending;

                    if (curr == next || Math.Abs(curr - next) > 3 || trajectory != expectedTrajectory)
                    {
                        safe = false;
                        break;
                    };
                }

                if (safe)
                {
                    newlySafeReports++;
                    break;
                }
            }
        }

        Console.WriteLine($"\nThe Dampening process has produced {newlySafeReports} safe reports");
        Console.WriteLine($"There are now {totalSafe + newlySafeReports} Safe Reports");
        Console.WriteLine($"Lines Processed {counter}");
    }
}

public enum LevelTrajectory
{
    Ascending,
    Descending
}

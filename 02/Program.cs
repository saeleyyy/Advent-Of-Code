int totalSafe = 0;
int totalUnsafe = 0;
int linesProcessed = 0;

foreach (var report in File.ReadLines("input.txt"))
{
    linesProcessed++;

    var levels = report.Split(" ").Select(int.Parse).ToArray();

    if (levels[0] == levels[1])
    {
        Console.WriteLine($"{report} - UnSafe");
        totalUnsafe++;
        continue;
    }

    LevelTrajectory trajectory = levels[0] > levels[1] ? LevelTrajectory.Descending : LevelTrajectory.Ascending;

    bool safe = true;
    foreach (var (curr, next) in levels.Zip(levels.Skip(1)))
    {
        var currentTrajectory = curr > next ? LevelTrajectory.Descending : LevelTrajectory.Ascending;
        if (currentTrajectory != trajectory)
        {
            safe = false;
        }

        if ((curr == next) || Math.Abs(curr - next) > 3)
        {
            safe = false;
        }
    }

    if (safe)
    {
        Console.WriteLine($"{report} - Safe");
        totalSafe++;
    }
    else
    {
        Console.WriteLine($"{report} - UnSafe");
        totalUnsafe++;
    }
}

Console.WriteLine($"\nTotal Safe Reports: {totalSafe}");
Console.WriteLine($"Total UnSafe Reports: {totalUnsafe}");
Console.WriteLine($"Lines Processed: {linesProcessed}");

public enum LevelTrajectory
{
    Ascending,
    Descending
}

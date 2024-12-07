var file = File.OpenText("input.txt");

var safeReports = 0;

while (file.ReadLine() is { } line)
{
    var report = line.Split(" ").Select(int.Parse).ToArray();

    var direction = report[0] - report[1] < 0;
    var isSafe = true;
    for (int i = 0, j = 1; j < report.Length; i++, j++)
    {
        var diff = report[i] - report[j];
        var currDirection = diff < 0;
        isSafe = currDirection == direction && (1 <= Math.Abs(diff) && Math.Abs(diff) <= 3);
        if (!isSafe)
        {
            break;
        }
    }

    if (isSafe)
    {
        safeReports++;
    }
}

Console.WriteLine(safeReports);

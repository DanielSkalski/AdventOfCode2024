var file = File.OpenText("input.txt");

var safeReports = 0;

while (file.ReadLine() is { } line)
{
    var report = line.Split(" ").Select(int.Parse).ToArray();

    var (isSafe, failedAt) = IsSafeSequence(report);
    if (!isSafe)
    {
        isSafe = IsSafeSequence([..report[..failedAt], ..report[(failedAt + 1)..]]).isSafe ||
                 IsSafeSequence([..report[..(failedAt + 1)], ..report[(failedAt + 2)..]]).isSafe ||
                (failedAt > 0 &&
                 IsSafeSequence([..report[..(failedAt - 1)], ..report[failedAt..]]).isSafe);
    }

    if (isSafe)
    {
        safeReports++;
    }
}

Console.WriteLine(safeReports);
return;

(bool isSafe, int failedAt) IsSafeSequence(int[] nums)
{
    var direction = nums[0] - nums[1] < 0;
    for (int i = 0, j = 1; j < nums.Length; i++, j++)
    {
        var diff = nums[i] - nums[j];
        var currDirection = diff < 0;
        var isSafe = currDirection == direction && (1 <= Math.Abs(diff) && Math.Abs(diff) <= 3);
        if (!isSafe)
        {
            return (false, i);
        }
    }

    return (true, -1);
}

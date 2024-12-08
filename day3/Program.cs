using System.Text.RegularExpressions;

var file = File.OpenText("input.txt");

var text = file.ReadToEnd();

const string pattern = @"mul\(\d+,\d+\)";
const string doPattern = @"do\(\)";
const string dontPattern = @"don\'t\(\)";

var disableIndexes = Regex.Matches(text, dontPattern).Select(x => (int?)x.Index).ToArray();
var enableIndexes = Regex.Matches(text, doPattern).Select(x => x.Index).ToArray();

var sum = 0;
foreach (Match match in Regex.Matches(text, pattern))
{
    var nearestDisableIndex = disableIndexes.LastOrDefault(x => x < match.Index) ?? -1;
    var nearestEnableIndex = enableIndexes.LastOrDefault(x => x < match.Index);

    var isEnabled = nearestEnableIndex > nearestDisableIndex;
    if (isEnabled)
    {
        var nums = match.Value[4..^1].Split(',').Select(int.Parse).ToArray();
        sum += nums[0] * nums[1];
    }
}

Console.WriteLine(sum);

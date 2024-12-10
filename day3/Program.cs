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

var pattern2 = @"(?<mul>mul)\((?<a>\d+),(?<b>\d+)\)|(?<dont>don't)\(\)|(?<do>do)\(\)";
var sum2 = Regex.Matches(text, pattern2).Select(match => match switch
{
    _ when match.Groups["dont"].Success => (Instruction)new DoNot(),
    _ when match.Groups["do"].Success => new Do(),
    _ => new Multiply(int.Parse(match.Groups["a"].Value), int.Parse(match.Groups["b"].Value)),
}).Aggregate((sum: 0, include: true), (curr, instruction) => instruction switch
{
    DoNot => (sum, false),
    Do => (sum, true),
    Multiply m when curr.include => (sum += m.A * m.B, curr.include),
    _ => curr,
}).sum;

Console.WriteLine(sum);
Console.WriteLine(sum2);

record Instruction();
record Multiply(int A, int B) : Instruction();
record Do() : Instruction();
record DoNot() : Instruction();

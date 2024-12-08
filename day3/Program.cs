using System.Text.RegularExpressions;

var file = File.OpenText("input.txt");

var text = file.ReadToEnd();

const string pattern = @"mul\(\d+,\d+\)";

var sum = 0;
foreach (Match match in Regex.Matches(text, pattern))
{
    var nums = match.Value[4..^1].Split(',').Select(int.Parse).ToArray();
    sum += nums[0] * nums[1];
}

Console.WriteLine(sum);

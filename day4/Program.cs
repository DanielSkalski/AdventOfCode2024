var file = File.OpenText("input.txt");

List<string> lines = [];

while (file.ReadLine() is { } line)
{
    lines.Add(line);
}

var wordsCount = 0;

for (var i = 1; i < lines.Count - 1; i++)
{
    var currLine = lines[i];
    for (var j = 1; j < currLine.Length - 1; j++)
    {
        if (currLine[j] == 'A')
        {
            if (((lines[i - 1][j - 1] == 'M' && lines[i + 1][j + 1] == 'S') || (lines[i - 1][j - 1] == 'S' && lines[i + 1][j + 1] == 'M')) &&
                ((lines[i + 1][j - 1] == 'M' && lines[i - 1][j + 1] == 'S') || (lines[i + 1][j - 1] == 'S' && lines[i - 1][j + 1] == 'M')))
            {
                wordsCount++;
            }
        }
    }
}

Console.WriteLine(wordsCount);

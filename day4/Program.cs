var file = File.OpenText("input.txt");

List<string> lines = [];

while (file.ReadLine() is { } line)
{
    lines.Add(line);
}

int wordsCount = 0;

for (int i = 0; i < lines.Count; i++)
{
    var currLine = lines[i];
    for (int j = 0; j < currLine.Length; j++)
    {
        if (currLine[j] == 'X')
        {
            if (j >= 3)
            {
                if (currLine[j - 1] == 'M' && currLine[j - 2] == 'A' && currLine[j - 3] == 'S')
                {
                    wordsCount++;
                }
            }
            if (j < currLine.Length - 3)
            {
                if (currLine[j + 1] == 'M' && currLine[j + 2] == 'A' && currLine[j + 3] == 'S')
                {
                    wordsCount++;
                }
            }

            if (i >= 3)
            {
                if (lines[i - 1][j] == 'M' && lines[i - 2][j] == 'A' && lines[i - 3][j] == 'S')
                {
                    wordsCount++;
                }
            }

            if (i < lines.Count - 3)
            {
                if (lines[i + 1][j] == 'M' && lines[i + 2][j] == 'A' && lines[i + 3][j] == 'S')
                {
                    wordsCount++;
                }
            }

            if (j >= 3 && i >= 3)
            {
                if (lines[i - 1][j - 1] == 'M' && lines[i - 2][j - 2] == 'A' && lines[i - 3][j - 3] == 'S')
                {
                    wordsCount++;
                }
            }

            if (j >= 3 && i < lines.Count - 3)
            {
                if (lines[i + 1][j - 1] == 'M' && lines[i + 2][j - 2] == 'A' && lines[i + 3][j - 3] == 'S')
                {
                    wordsCount++;
                }
            }

            if (j < currLine.Length - 3 && i >= 3)
            {
                if (lines[i - 1][j + 1] == 'M' && lines[i - 2][j + 2] == 'A' && lines[i - 3][j + 3] == 'S')
                {
                    wordsCount++;
                }
            }

            if (j < currLine.Length - 3 && i < lines.Count - 3)
            {
                if (lines[i + 1][j + 1] == 'M' && lines[i + 2][j + 2] == 'A' && lines[i + 3][j + 3] == 'S')
                {
                    wordsCount++;
                }
            }
        }
    }
}

Console.WriteLine(wordsCount);

using var file = File.OpenText("input.txt");

Dictionary<int, List<int>> mustPrintBefore = [];

List<List<int>> pageUpdatesToPrint = [];

bool loadingPageOrderRules = true;

while (file.ReadLine() is { } line)
{
    if (string.IsNullOrWhiteSpace(line))
    {
        loadingPageOrderRules = false;
        continue;
    }

    if (loadingPageOrderRules)
    {
         var rule = line.Split("|").Select(int.Parse).ToArray();
         var before = rule[0];
         var after = rule[1];

         if (!mustPrintBefore.TryGetValue(before, out var value))
         {
             value = ([]);
             mustPrintBefore[before] = value;
         }
         value.Add(after);
    }
    else
    {
        pageUpdatesToPrint.Add(line.Split(",").Select(int.Parse).ToList());
    }
}

var sum = 0;
foreach (var pagesUpdate in pageUpdatesToPrint)
{
    bool canPrint = true;
    for (var i = 1; i < pagesUpdate.Count; i++)
    {
        if (mustPrintBefore.TryGetValue(pagesUpdate[i], out var mustBeAfter))
        {
            if (pagesUpdate[..i].Intersect(mustBeAfter).Any())
            {
                canPrint = false;
                break;
            }
        }
    }

    if (canPrint)
    {
        var midPoint = (pagesUpdate.Count - 1) / 2;
        sum += pagesUpdate[midPoint];
    }
}

Console.WriteLine(sum);

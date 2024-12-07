using var file = File.OpenText("input.txt");

List<int> list1 = [];
List<int> list2 = [];

while (file.ReadLine() is {} line)
{
    var numbers = line.Split(" ");
    list1.Add(int.Parse(numbers[0]));
    list2.Add(int.Parse(numbers[^1]));
}

Dictionary<int, int> lookup = [];

foreach (var number in list2)
{
    if (lookup.ContainsKey(number))
    {
        lookup[number]++;
    }
    else
    {
        lookup[number] = 1;
    }
}

var result = list1.Aggregate(0, (curr, num) => curr + (lookup.ContainsKey(num) ? num * lookup[num] : 0));

Console.WriteLine(result);

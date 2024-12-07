using var file = File.OpenText("input.txt");

List<int> list1 = [];
List<int> list2 = [];

while (file.ReadLine() is {} line)
{
    var numbers = line.Split(" ");
    list1.Add(int.Parse(numbers[0]));
    list2.Add(int.Parse(numbers[^1]));
}

var result = list1.Order().Zip(list2.Order(), (a, b) => Math.Abs(a - b)).Sum();

Console.WriteLine(result);

using var file = File.OpenText("input.txt");

var map = new List<string>();

int posX = -1;
int posY = 0;
while (file.ReadLine() is { } line)
{
    map.Add(line);

    if (posX == -1)
    {
        posX = line.IndexOf('^');
    }
    if (posX == -1)
    {
        posY++;
    }
}
var borderX = map[0].Length;
var borderY = map.Count;

var directionX = 0;
var directionY = -1;

var visitedPlaces = new Dictionary<(int, int), bool>(){ [(posX, posY)] = true };

while (true)
{
    var newPosX = posX + directionX;
    var newPosY = posY + directionY;

    if (newPosX == borderX || newPosX == -1 || newPosY == borderY || newPosY == -1)
    {
        break;
    }

    if (map[newPosY][newPosX] == '#')
    {
        if (directionX == 0 && directionY == -1)
        {
            (directionX, directionY) = (1, 0);
        }
        else if (directionX == 1 && directionY == 0)
        {
            (directionX, directionY) = (0, 1);
        }
        else if (directionX == 0 && directionY == 1)
        {
            (directionX, directionY) = (-1, 0);
        }
        else if (directionX == -1 && directionY == 0)
        {
            (directionX, directionY) = (0, -1);
        }
    }

    posX += directionX;
    posY += directionY;
    if (!visitedPlaces.ContainsKey((posX, posY)))
    {
        visitedPlaces[(posX, posY)] = true;
    }
}

Console.WriteLine(visitedPlaces.Count);

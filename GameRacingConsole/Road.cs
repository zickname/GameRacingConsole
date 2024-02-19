namespace GameRacingConsole;

class Road
{
    public const int RoadLength = 150;
    private const int RoadHeight = 9;
    private readonly List<string> road;
    private readonly char borderChar = '#';
    public Road()
    {
        road = new List<string>();
        InitializeRoad();
    }

    private void InitializeRoad()
    {
        for (int i = 0; i < RoadHeight; i++)
        {
            if (i == 0 || i == 4 || i == RoadHeight-1)
            {
                string roadLine = new string(borderChar, RoadLength - 1) + "||";
                road.Add(roadLine);
                continue;
            }
            road.Add(new string(' ', RoadLength-1) + "||");
        }
    }

    public void PlaceCar(Car car)
    {
        char[,] carShape = car.GetShape();
        int carHeight = carShape.GetLength(0);
        int carWidth = carShape.GetLength(1);

        for (int i = 0; i < carHeight; i++)
        {
            for (int j = 0; j < carWidth; j++)
            {
                int posX = car.X + j;
                int posY = car.Y + i;
                if (posX >= 0 && posX < RoadLength && posY >= 0 && posY < RoadHeight)
                {
                    char carPixel = carShape[i, j];
                    if (carPixel != ' ')
                    {
                        string roadLine = road[posY];
                        roadLine = roadLine.Remove(posX, 1).Insert(posX, carPixel.ToString());
                        road[posY] = roadLine;
                    }
                }
            }
        }
    }

    public void Draw()
    {
        Console.CursorVisible = false;
        foreach (var roadLine in road)
        {
            Console.WriteLine(roadLine);
        }
    }
}

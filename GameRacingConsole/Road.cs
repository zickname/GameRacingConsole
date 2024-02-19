namespace GameRacingConsole;

class Road
{
    private const int RoadHeight = 9;
    private readonly List<string> _road;
    private const char _borderChar = '#';
    public const int RoadLength = 150;

    public Road()
    {
        _road = new List<string>();
        InitializeRoad();
    }

    private void InitializeRoad()
    {
        for (int i = 0; i < RoadHeight; i++)
        {
            if (i == 0 || i == 4 || i == RoadHeight-1)
            {
                string roadLine = new string(_borderChar, RoadLength - 1) + "||";
                _road.Add(roadLine);
                continue;
            }
            _road.Add(new string(' ', RoadLength-1) + "||");
        }
    }

    public void PlaceCar(Car car)
    {
        char[,] carShape = car.GetShape();
        int carHeight = carShape.GetLength(0);
        int carWidth = carShape.GetLength(1);
    
        for (int y = 0; y < carHeight; y++)
        {
            for (int x = 0; x < carWidth; x++)
            {
                int posX = car.X + x;
                int posY = car.Y + y;
                
                if (car.X + carWidth > RoadLength-1)
                {
                    posX = RoadLength - carWidth - 1 + x;
                }

                char carPixel = carShape[y, x];

                if (carPixel == ' ') continue;
                
                string roadLine = _road[posY];
                roadLine = roadLine.Remove(posX, 1).Insert(posX, carPixel.ToString());
                _road[posY] = roadLine;
            }
        }
    }

    public void RemoveCar(Car car)
    {
        char[,] carShape = car.GetShape();
        int carHeight = carShape.GetLength(0);
        int carWidth = carShape.GetLength(1);

        for (int y = 0; y < carHeight; y++)
        {
            for (int x = 0; x < carWidth; x++)
            {
                int posX = car.X + x;
                int posY = car.Y + y;

                if (car.X + carWidth > RoadLength - 1)
                {
                    posX = RoadLength - carWidth - 1 + x;
                }

                string roadLine = _road[posY];
                roadLine = roadLine.Remove(posX, 1).Insert(posX, ' '.ToString());
                _road[posY] = roadLine;
            }
        }
    }
    
    public void Draw()
    {
        Console.CursorVisible = false;
        foreach (var roadLine in _road)
        {
            Console.WriteLine(roadLine);
        }
    }
}

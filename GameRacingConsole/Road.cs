namespace GameRacingConsole;

class Road
{
    private int RoadLength { get; }
    private int RoadHeight { get; }
    private const char TrackBorderChar = '#';
    private readonly List<string> _roadLine = new();

    public Road(int roadLength)
    {
        RoadLength = roadLength;
        RoadHeight = 9;
        InitializeRoad();
    }

    private void InitializeRoad()
    {
        for (int i = 0; i < RoadHeight; i++)
        {
            if (i == 0 || i == 4 || i == RoadHeight - 1)
            {
                var roadLine = new string(TrackBorderChar, RoadLength) + "||";
                _roadLine.Add(roadLine);
                continue;
            }

            _roadLine.Add(new string(' ', RoadLength) + "||");
        }
    }

    public int getRoadLength() => RoadLength;

    public void PlaceCar(Car car)
    {
        char[,] carShape = car.GetCarSprite();
        int carHeight = car.GetHeight();
        int carWidth = car.GetWidth();

        for (int y = 0; y < carHeight; y++)
        {
            int posY = car.Y + y;

            for (int x = 0; x < carWidth; x++)
            {
                int posX = car.X + x;

                if (car.X > RoadLength) posX = RoadLength + x;

                char carPixel = carShape[y, x];

                if (carPixel == ' ') continue;

                string roadLine = _roadLine[posY];
                roadLine = roadLine.Remove(posX - carWidth, 1).Insert(posX - carWidth, carPixel.ToString());
                _roadLine[posY] = roadLine;
            }
        }
    }

    public void RemoveCar(Car car)
    {
        char[,] carShape = car.GetCarSprite();
        int carHeight = carShape.GetLength(0);
        int carWidth = carShape.GetLength(1);

        for (int y = 0; y < carHeight; y++)
        {
            int posY = car.Y + y;

            for (int x = 0; x < carWidth; x++)
            {
                int posX = car.X + x;

                if (car.X > RoadLength) posX = RoadLength + x;

                string roadLine = _roadLine[posY];
                roadLine = roadLine.Remove(posX - carWidth, 1).Insert(posX - carWidth, ' '.ToString());
                _roadLine[posY] = roadLine;
            }
        }
    }

    public void Draw()
    {
        Console.CursorVisible = false;
        foreach (var roadLine in _roadLine)
        {
            Console.WriteLine(roadLine);
        }
    }
}
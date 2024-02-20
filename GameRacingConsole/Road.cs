namespace GameRacingConsole;

class Road
{
    public int RoadLength { get; private set; }
    private int _roadHeight { get; }
    private const char RoadBorderChar = '#';
    private readonly List<string> _roadLine = new();

    public Road(int roadLength)
    {
        RoadLength = roadLength;
        _roadHeight = 9;
        InitializeRoad();
    }

    private void InitializeRoad()
    {
        for (int i = 0; i < _roadHeight; i++)
        {
            if (i == 0 || i == 4 || i == _roadHeight - 1)
            {
                var roadLine = new string(RoadBorderChar, RoadLength) + "||";
                _roadLine.Add(roadLine);
                continue;
            }

            _roadLine.Add(new string(' ', RoadLength) + "||");
        }
    }

    public void PlaceCar(Car[] cars)
    {
        foreach (var car in cars)
        {
            char[,] carShape = car.sprite;
            int carHeight = car.Height;
            int carWidth = car.Width;

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
    }

    public void RemoveCar(Car[] cars)
    {
        foreach (var car in cars)
        {
            char[,] carShape = car.sprite;
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
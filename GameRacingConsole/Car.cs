namespace GameRacingConsole;

class Car
{
    private readonly Random _random = new ();
    private readonly Sprite _carSprite;
    public string Name { get; }
    public int X { get; private set; }
    public int Y { get; private set; }

    public Car(string name, Sprite sprite)
    {
        Name = name;
        _carSprite = sprite;
        X = 0;
        Y = 0;
    }
    
    public void Move()
    {
        X += _random.Next(1, 8); // Случайное число от 1 до 5 для перемещения по горизонтали
    }

    public void SetPosition(int x, int y)
    {
        X = x;
        Y = y;
    }

    public char[,] GetShape()
    {
        return _carSprite.SpriteCar;
    }
}
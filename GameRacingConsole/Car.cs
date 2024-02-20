namespace GameRacingConsole;

class Car
{
    public string Name { get; }
    public int X { get; private set; }
    public int Y { get; private set; }
    private readonly Random _random = new ();
    private readonly char [,] sprite;

    public Car(string name, char [,] sprite)
    {
        Name = name;
        X = 0;
        Y = 0;
        this.sprite = sprite;
    }
    
    public void Move()
    {
        X += _random.Next(1, 3); // Случайное число от 1 до 5 для перемещения по горизонтали
    }

    public void SetPosition(int x, int y)
    {
        X = x + sprite.GetLength(1);
        Y = y;
    }

    public char[,] GetCarSprite() => sprite;

    public int GetWidth() => GetCarSprite().GetLength(1);

    public int GetHeight() => GetCarSprite().GetLength(0);
}
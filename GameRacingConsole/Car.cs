namespace GameRacingConsole;

class Car
{
    public string Name { get; }
    public int X { get; private set; }
    public int Y { get; private set; }
    private readonly Random random = new Random();
    private readonly Sprite carSprite;

    public Car(string name, Sprite sprite)
    {
        Name = name;
        carSprite = sprite;
        X = 0;
        Y = 0;
    }
    
    public void Move()
    {
        X += random.Next(1, 10); // Случайное число от 1 до 5 для перемещения по горизонтали
    }

    public void SetPosition(int x, int y)
    {
        X = x;
        Y = y;
    }

    public char[,] GetShape()
    {
        return carSprite.SpriteCar;
    }
}
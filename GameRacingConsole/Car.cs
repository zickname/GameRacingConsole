namespace GameRacingConsole;

class Car
{
    public string Name { get; }
    public char [,] sprite { get; private set; }
    public int Width { get; private set; }
    public int Height { get; private set; }
    public int X { get; private set; }
    public int Y { get; private set; }
    private readonly Random _random = new ();

    public Car(string name, char [,] sprite, (int, int) position)
    {
        Name = name;
        this.sprite = sprite;
        Width = sprite.GetLength(1);
        Height = sprite.GetLength(0);
        X = position.Item1 + Width;
        Y = position.Item2;
    }
    
    public void Move()
    {
        X += _random.Next(1, 3); // Случайное число от 1 до 5 для перемещения по горизонтали
    }
}
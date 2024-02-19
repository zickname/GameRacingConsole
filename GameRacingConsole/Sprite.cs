namespace GameRacingConsole;

struct Sprite
{
    public readonly char[,] SpriteCar;

    public Sprite()
    {
        SpriteCar = new[,]
        {
            { ' ', ' ', '_', '_', '_', '\0', '\0', '\0', '\0', '\0' },
            { ' ', '/', '_', '|', '_', '\\', '_', '_', '_', '\0' },
            { '(', '0', '-', '-', '-', '-', '0', ')', '-', ')' }
        };
    }
}
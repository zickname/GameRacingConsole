using GameRacingConsole;

var game = new Game();

Console.Write($"Чтобы начать игру, нажмите 'Enter': ");

while (true)
{
    if (Console.ReadKey(true).Key == ConsoleKey.Enter)
    {
        game.RunRace();
        Console.ReadKey();
        break;
    }

    if (Console.ReadKey(true).Key == ConsoleKey.Escape)
    {
        break;
    }
}
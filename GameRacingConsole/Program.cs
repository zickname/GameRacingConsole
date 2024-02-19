using GameRacingConsole;

var game = new RaceGame();

Console.Write($"Чтобы начать игру, нажмите 'Enter': ");

while (true)
{
    if (Console.ReadKey(true).Key == ConsoleKey.Enter)
    {
        game.RunRace();
    }
}
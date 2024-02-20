using GameRacingConsole;

var game = new Game();

Console.Write($"Чтобы начать игру, нажмите 'Enter': ");

while (true)
{
    if (Console.ReadKey(true).Key != ConsoleKey.Enter) continue;
    game.RunRace();
    Console.ReadKey();
    break;
}
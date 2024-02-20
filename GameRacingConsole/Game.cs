namespace GameRacingConsole;

class Game
{
    private readonly Car _car1;
    private readonly Car _car2;
    private readonly Road _road = new(100);
    private bool _raceOver;

    public Game()
    {
        _car1 = new Car("Машина 1", Sprite.SpriteCar);
        _car2 = new Car("Машина 2", Sprite.SpriteCar);
        _car1.SetPosition(0, 1);
        _car2.SetPosition(0, 5);
        _raceOver = false;
    }

    public void RunRace()
    {
        Console.WriteLine("Гонка начинается!");
        while (!_raceOver)
        {
            Console.SetCursorPosition(0, 0);
            _road.PlaceCar(_car1);
            _road.PlaceCar(_car2);
            _road.Draw();
            CheckWinner();
            _road.RemoveCar(_car1);
            _road.RemoveCar(_car2);
            _car1.Move();
            _car2.Move();
            Thread.Sleep(100); // Для эффекта анимации, если нужно
        }
    }

    private void CheckWinner()
    {
        int roadWidth = _road.getRoadLength();
        bool car1ReachedEnd = (_car1.X >= roadWidth);
        bool car2ReachedEnd = (_car2.X >= roadWidth);
        
        if (!car2ReachedEnd && !car1ReachedEnd) return;
        _raceOver = true;
        Console.WriteLine("Гонка завершена!");

        if (car1ReachedEnd && car2ReachedEnd)
            ShowInfo("Ничья!");
        else if (car1ReachedEnd)
            ShowInfo($"{_car1.Name} победил!");
        else
            ShowInfo($"{_car2.Name} победил!");
    }

    private static void ShowInfo(string message)
    {
        Console.WriteLine(message);
    }
}


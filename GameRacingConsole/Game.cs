namespace GameRacingConsole;

class Game
{
    private readonly Car[] _cars = new[]
    {
        new Car("Машина 1", Sprite.SpriteCar, (0, 1)),
        new Car("Машина 2", Sprite.SpriteCar, (0, 5))
    };

    private readonly Road _road = new(100);
    private bool _raceOver;

    public Game()
    {
        _raceOver = false;
    }

    public void RunRace()
    {
        Console.WriteLine("Гонка начинается!");
        while (!_raceOver)
        {
            _road.PlaceCar(_cars);
            _road.Draw();
            CheckWinner();
            _road.RemoveCar(_cars);
            foreach (Car car in _cars)
            {
                car.Move();
            }

            Thread.Sleep(100); // Для эффекта анимации, если нужно
        }
    }

    private void CheckWinner()
    {
        var roadWidth = _road.RoadLength;
        var carReachedEnd = new bool[_cars.Length];

        for (var i = 0; i < _cars.Length; i++) carReachedEnd[i] = _cars[i].X >= roadWidth;

        var anyCarReachedEnd = carReachedEnd.Any(reachedEnd => reachedEnd);
        if (!anyCarReachedEnd) return;

        _raceOver = true;
        ShowInfo("Гонка завершена!");

        var winnersCount = carReachedEnd.Count(reachedEnd => reachedEnd);

        if (winnersCount > 1)
        {
            ShowInfo("Ничья!");
        }
        else
        {
            var winnerIndex = Array.FindIndex(carReachedEnd, reachedEnd => reachedEnd);
            ShowInfo($"{_cars[winnerIndex].Name} победил!");
        }
    }

    private static void ShowInfo(string message)
    {
        Console.WriteLine(message);
    }
}
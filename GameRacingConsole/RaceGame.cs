namespace GameRacingConsole;
class RaceGame
{
    private readonly Car _car1;
    private readonly Car _car2;
    private readonly Road _road = new();
    private bool _raceOver;

    public RaceGame()
    {
        var carSprite = new Sprite();
        _car1 = new Car("Машина 1", carSprite);
        _car2 = new Car("Машина 2", carSprite);
        _car1.SetPosition(0,1);
        _car2.SetPosition(0,5);
        _raceOver = false;
    }

    public void RunRace()
    {
        Console.WriteLine("Гонка начинается!");
        while (!_raceOver)
        {
            Console.SetCursorPosition(0,0);
            _road.RemoveCar(_car1);
            _road.RemoveCar(_car2);
            _car1.Move();
            _car2.Move();
            _road.PlaceCar(_car1);
            _road.PlaceCar(_car2);
            _road.Draw();
            CheckWinner();
            Thread.Sleep(100); // Для эффекта анимации, если нужно
        }
    }

    private void CheckWinner()
    {
        if (_car1.X + _car1.GetShape().GetLength(1) <= Road.RoadLength - 1 &&
            _car2.X + _car1.GetShape().GetLength(1) <= Road.RoadLength - 1) return;
        _raceOver = true;
        Console.WriteLine("Гонка завершена!");
        if (_car1.X + _car1.GetShape().GetLength(1) > Road.RoadLength - 1 &&
            _car2.X + _car1.GetShape().GetLength(1) > Road.RoadLength - 1)
            Console.WriteLine("Ничья!");
        else if (_car1.X + _car1.GetShape().GetLength(1) > Road.RoadLength - 1)
            Console.WriteLine($"{_car1.Name} победил!");
        else
            Console.WriteLine($"{_car2.Name} победил!");
    }
}

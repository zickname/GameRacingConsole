namespace GameRacingConsole;
class RaceGame
{
    private readonly Car car1;
    private readonly Car car2;
    private Road road;
    private bool raceOver;

    public RaceGame()
    {
        var carSprite = new Sprite();
        car1 = new Car("Машина 1", carSprite);
        car2 = new Car("Машина 2", carSprite);
        car1.SetPosition(0,1);
        car2.SetPosition(0,5);
        raceOver = false;
    }

    public void RunRace()
    {
        Console.WriteLine("Гонка начинается!");
        while (!raceOver)
        {
            Console.SetCursorPosition(0,0);
            road = new Road();
            road.PlaceCar(car1);
            road.PlaceCar(car2);
            car1.Move();
            car2.Move();
            road.Draw();
            Thread.Sleep(100); // Для эффекта анимации, если нужно
            CheckWinner();
        }
    }

    private void CheckWinner()
    {
        if (car1.X + car1.GetShape().GetLength(1)/2+1 >= Road.RoadLength - 1 || (car2.X + car1.GetShape().GetLength(1)/2+1 >= Road.RoadLength - 1))
        {
            raceOver = true;
            Console.WriteLine("Гонка завершена!");
            if (car1.X + car1.GetShape().GetLength(1)/2+1 >= Road.RoadLength - 1 && car2.X >= Road.RoadLength - 1)
                Console.WriteLine("Ничья!");
            else if (car1.X + car1.GetShape().GetLength(1)/2+1 >= Road.RoadLength - 1)
                Console.WriteLine($"{car1.Name} победил!");
            else
                Console.WriteLine($"{car2.Name} победил!");
        }
    }
}

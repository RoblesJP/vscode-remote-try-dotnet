public enum CarType
{
  Sedan,
  Crossover
}

class Car
{
  public CarType Type;
  public int WheelSize;
}

interface ISpecifyCarType
{
  ISpecifyWheelSize OfType(CarType type);
}

interface ISpecifyWheelSize
{
  IBuildCar WithWheels(int size);
}

interface IBuildCar
{
  public Car Build();
}

class Program
{
  static void Main()
  {
    Console.WriteLine("Hello World!");
  }
}
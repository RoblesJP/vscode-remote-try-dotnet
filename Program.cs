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

// applying interface segregation principle
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

class CarBuilder
{
  private class Impl : ISpecifyCarType, ISpecifyWheelSize, IBuildCar
  {
    private Car car = new Car();

    public ISpecifyWheelSize OfType(CarType type)
    {
      car.Type = type;
      return this;
    }

    public IBuildCar WithWheels(int size)
    {
      switch (car.Type)
      {
        case CarType.Crossover when size < 17 || size > 20:
        case CarType.Sedan when size < 15 || size > 17:
          throw new ArgumentException($"Wrong size of wheel for {car.Type}");
      }

      car.WheelSize = size;
      return this;
    }

    public Car Build()
    {
      return car;
    }
  }
  public static ISpecifyCarType Create()
  {
    return new Impl();
  }
}

class Program
{
  static void Main()
  {
    var car = CarBuilder.Create()
      .OfType(CarType.Sedan)
      .WithWheels(16)
      .Build();

    Console.WriteLine(car);
  }
}
public class Point
{
  private double x;
  private double y;

  private Point(double x, double y)
  {
    this.x = x;
    this.y = y;
  }

  public static Point Origin = new Point(0, 0);

  public class Factory
  {
    // factory method
    public static Point NewCartesianPoint(double x, double y)
    {
      return new Point(x, y);
    }

    // factory method
    public static Point NewPolarPoint(double rho, double theta)
    {
      return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
    }
  }
}



class Program
{
  static void Main()
  {
    var point = Point.Factory.NewCartesianPoint(3, 2);
    Console.WriteLine(point);

    var origin = Point.Origin;
  }
}
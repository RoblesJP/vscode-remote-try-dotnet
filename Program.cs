public class Point
{
  private double x;
  private double y;

  public Point(double x, double y)
  {
    this.x = x;
    this.y = y;
  }
}

public class PointFactory
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

class Program
{
  static void Main()
  {
    var point = PointFactory.NewCartesianPoint(3, 2);
  }
}
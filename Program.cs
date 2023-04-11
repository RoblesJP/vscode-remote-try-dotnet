public class Point
{
  private double x;
  private double y;

  private Point(double x, double y)
  {
    this.x = x;
    this.y = y;
  }

  private async Task<Point> InitAsync()
  {
    await Task.Delay(1000);
    return this;
  }

  public static Task<Point> CreateAsync(double x, double y)
  {
    var result = new Point(x, y);
    return result.InitAsync();
  }
}



class Program
{
  static void Main()
  {
    var x = Point.CreateAsync(3, 2);
  }
}
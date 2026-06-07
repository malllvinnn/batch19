namespace Struct
{
  readonly struct Point2
  {
    public readonly int X, Y;

    public Point2(int x, int y)
    {
      X = x;
      Y = y;
    }

    // readonly method
    public int RandomNumber()
    {
      Random random = new Random();

      return random.Next(1, 100);
    }
  }
}
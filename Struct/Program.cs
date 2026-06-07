namespace Struct
{
  class Program
  {
    public static void Main(string[] args)
    {
      // Struct Copy by value
      Point p1 = new Point { X = 7, Y = 19 };
      Point p2 = p1; // <-- copy semua value

      Console.WriteLine(p1.GetType() == p2.GetType());
      // Output: True

      Console.WriteLine(p1.X == p2.X);
      // Output: True

      p1.X = 62;
      Console.WriteLine(p1.X); // Output: 62
      Console.WriteLine(p2.X); // Output: 7
      Console.WriteLine(p1.X == p2.X); // <-- tidak sama lagi
      // Output: False

      // Class Copy Reference
      PointClass c1 = new PointClass { X = 7, Y = 19 };
      PointClass c2 = c1; // <-- copy reference

      Console.WriteLine(c1.GetType() == c2.GetType());
      // Output: True

      Console.WriteLine(c1.X == c2.X);
      // Output: True

      c1.X = 62;
      Console.WriteLine(c1.X); // Output: 62
      Console.WriteLine(c2.X); // Output: 62 //<-- Ikut berubah
      Console.WriteLine(c1.X == c2.X); // <-- Tetap sama
                                       // Output: True

      // READONLY STRUCT IMPLEMENTATION
      Point2 p21 = new Point2(21, 31);

      Console.WriteLine($"{p21.X} + {p21.Y} = {p21.X + p21.Y}");
      // Output: 21 + 31 = 52

      Console.WriteLine(p21.RandomNumber());
      // Output: 58

      // don't try re-assign
      // p21.X = 21; // ERROR
      // dst
    }
  }
}
namespace TheType
{
  class Program
  {
    public static void Main(string[] args)
    {
      Point p = new Point(15, 17);

      // GetType() — runtime, instance method
      Console.WriteLine(p.GetType().Name);
      // Output: Point

      Console.WriteLine(p.X.GetType().Name);
      // Output: Int32

      if (p.Y.GetType().Name == "Int32")
      {
        Console.WriteLine("Int 32 Bro");
      }
      // Output: Int 32 Bro

      // typeof — compile time, operator
      Console.WriteLine(typeof(Point).Name);
      // Output: Point

      // Keduanya menghasilkan tipe yang sama
      Console.WriteLine(p.GetType() == typeof(Point));
      // Output: True

      // ToString Override
      Panda petey = new Panda { Name = "Petey" };

      Console.WriteLine($"This is {petey}");
      // Output: This is Petey
    }
  }
}
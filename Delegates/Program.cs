namespace Delegates
{
    class Program
    {
        delegate int Transformer(int X);
        public static void Main(string[] args)
        {
            // DELEGATES BASIC
            int Square(int x)
            {
                return x * x;
            }

            int Cube(int x)
            {
                return x * x * x;
            }

            Transformer t = Square;

            int result1 = t(3);
            Console.WriteLine(result1);
            // Output: 9

            t = Cube;
            int result2 = t(3);
            Console.WriteLine(result2);
            // Output: 27
        }
    }
}
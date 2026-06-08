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

            void Transform(int[] values, Transformer t)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = t(values[i]);
                }
            }

            int[] values = { 1, 2, 3 };

            Transform(values, Square);
            foreach (int v in values) Console.Write(v + " "); // 1 4 9

            Transform(values, Cube);
            foreach (int v in values) Console.Write(v + " "); // 1 64 729
        }
    }
}
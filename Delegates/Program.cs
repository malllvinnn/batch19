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

            Console.WriteLine("\n");

            // Delegate Func & Action
            // Func (Return Value)
            Func<int, string, string> Intro = (age, name) => $"Hello saya {name}, usia {age}";
            Console.WriteLine(Intro(25, "Malfin"));
            // Output: Hello saya Malfin, usia 25

            // Action (Void)
            Action<string> SayHelo = (name) => Console.WriteLine($"Hello {name}");
            SayHelo("Victor");
            // Output: Hello Victor

            void Transform2<T>(T[] values, Func<T, T> transformer)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = transformer(values[i]);
                }
            }

            int[] nums = { 1, 2, 3, 4 };
            Transform2(nums, x => x * x);

            foreach (int num in nums)
            {
                Console.WriteLine(num);
            }
            /*  Output:
                1
                4
                9
                16
            */
        }
    }
}
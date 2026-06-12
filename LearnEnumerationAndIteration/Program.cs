namespace LearnEnumerationAndIteration
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Foreach High Level Iteration
            foreach (char b in "beer")  // "beer" is an enumerable object (string implements IEnumerable<char>)
            {
                Console.WriteLine(b);
            }
            /*  Output:
                b
                e
                e
                r
            */

            // Low LEvel Itertation
            using (var enumerator = "marjan".GetEnumerator()) // Get an enumerator from the enumerable object
            {
                while (enumerator.MoveNext()) // Move to the next element
                {
                    var element = enumerator.Current; // Get the current element
                    Console.WriteLine(element);
                }
            }
            /*  Output:
                m
                a
                r
                j
                a
                n
            */

            // Method Iteration Checker
            void HandlerCheckerCollection<T>(IEnumerable<T> values)
            {
                foreach (T value in values)
                {
                    Console.WriteLine(value);
                }

            }

            // Collection Initializer
            List<int> list1 = new List<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(4);

            HandlerCheckerCollection(list1);
            // Output: 1 2 4

            // Collection initializer — lebih singkat!
            List<string> names = new List<string> { "Mafle", "Lorem", "Mocha" };
            HandlerCheckerCollection(names);
            /*  Output:
                Mafle
                Lorem
                Mocha
            */

            // Dictionary initializer
            Dictionary<int, string> dict = new Dictionary<int, string>()
            {
                {1, "Lorem"},
                {2, "Venrir"},
                {3, "Bule"}
            };

            // Bisa pakai ini (iterasi biasa)
            HandlerCheckerCollection(dict);
            /*  Output:
                [1, Lorem]
                [2, Venrir]
                [3, Bule]
            */

            // Atau Spesifik (Get Key / Value)
            foreach (var d in dict)
            {
                Console.WriteLine($"{d.Key}: {d.Value}");
            }
            /*  Output:
                1: Lorem
                2: Venrir
                3: Bule
            */

            // C# 12+ — Collection expressions (paling singkat!)
            List<int> list2 = [1, 3, 5, 7];
            HandlerCheckerCollection(list2);
            // Output: 1 3 5 7

            int[] isArray = [1, 2, 4, 5];
            HandlerCheckerCollection(isArray);
            // Output: 1 2 4 5

            // Iterator method — return IEnumerable<T>
            IEnumerable<int> CountDown(int from)
            {
                for (int i = from; i >= 0; i--)
                {
                    yield return i;
                }
            }

            foreach (int n in CountDown(7))
            {
                Console.Write(n + " ");
            }
            // Output: 7 6 5 4 3 2 1 0

            // Fibonacci iterator
            IEnumerable<int> Fibs(int fibCount)
            {
                for (int i = 0, prevFib = 1, curFib = 1; i < fibCount; i++)
                {
                    yield return prevFib;
                    int newFib = prevFib + curFib;
                    prevFib = curFib;
                    curFib = newFib;
                }
            }

            foreach (int fib in Fibs(6))
            {
                Console.Write(fib + " ");
            }
            // Output: 1 1 2 3 5 8

            Console.WriteLine("");

            // LAZY EVOLUTION
            // Iterator — lazy! Tidak ada yang dihitung sampai di-iterate
            IEnumerable<int> GetNumbers()
            {
                Console.WriteLine("Start");
                yield return 1;
                Console.WriteLine("After 1");
                yield return 2;
                Console.WriteLine("After 2");
                yield return 3;
                Console.WriteLine("End");

            }

            // Hanya memanggil method — TIDAK ada yang dieksekusi!
            IEnumerable<int> numbers = GetNumbers();

            // Baru dieksekusi saat di-iterate!
            foreach (int number in numbers)
            {
                Console.Write(number + " ");
            }
            /*  Output:
                Start
                1 After 1
                2 After 2
                3 End
            */
        }
    }
}


namespace LearnGenerics
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Constraints
            void PrintDocument<T>(T document) where T : IPrintable
            {
                document.Print();
            }

            PrintDocument<Invoice>(new Invoice("INV-06082026"));
            // Output: Invoice: INV-06082026

            PrintDocument<Report>(new Report("Q1 Report"));
            // Output: Title: Q1 Report

            void ClearArray<T>(T[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = default!;
                }
            }

            int[] numbers = { 1, 2, 4, 2, 5, 6, 12, 45, 6, 19 };
            ClearArray(numbers);

            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
            /*  Output:
                0
                0
                0
                0
                0
                0
                0
                0
                0
                0
            */
        }
    }
}
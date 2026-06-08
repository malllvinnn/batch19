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
        }
    }
}
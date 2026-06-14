namespace LearnTryCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare basic try-catch
            int Calc(int x) => 10 / x;

            try
            {
                int y = Calc(0);
                Console.WriteLine($"y: {y}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
            // Output: Error Attempted to divide by zero.

            // Multiple Exception
            try
            {
                byte b = byte.Parse(args[0]);
                Console.WriteLine(b);
            }
            catch (IndexOutOfRangeException) // More specific
            {
                Console.WriteLine("Please provide at least one argument.");
            }
            catch (FormatException) // More specific
            {
                Console.WriteLine("That's not a number!");
            }
            catch (OverflowException) // More specific
            {
                Console.WriteLine("You've given me more than a byte!");
            }
            catch (Exception ex) // General fallback (must be last)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            // Output: Please provide at least one argument.

            // Finally Practice
            // void ReadFile()
            // {
            //     StreamReader reader = null;
            //     try
            //     {
            //         reader = File.OpenText("file.txt");
            //         Console.WriteLine(reader.ReadToEnd());
            //     }
            //     finally
            //     {
            //         reader?.Dispose();
            //     }
            // }
            // ReadFile();

            // using (StreamReader reader = File.OpenText("file.txt"))
            // {
            //     Console.WriteLine(reader.ReadToEnd());
            // }

            // void ReadFile()
            // {
            //     using var reader = File.OpenText("file.txt");
            //     Console.WriteLine(reader.ReadToEnd());
            // }
            // ReadFile();

            // Throwing Exception
            void SayHello(string? name)
            {
                try
                {
                    if (name == null | name?.Length == 0 | name == "")
                        throw new ArgumentNullException(nameof(name), "Name cannot be null or empty.");

                    Console.WriteLine($"Hello {name}");
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine($"Error Message: {ex.Message}");
                    Console.WriteLine($"Error Stack Trace {ex.StackTrace}");
                    Console.WriteLine($"Error Inner Exception {ex.InnerException?.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
            }
            SayHello("");
            // Error Name cannot be null or empty. (Parameter 'name')
        }
    }
}
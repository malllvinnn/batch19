namespace LearnStringBasic;

class ComparingString
{
  public static void Learn()
  {
    Console.WriteLine("Comparing String");

    Console.WriteLine(string.Equals("foo", "FOO", StringComparison.OrdinalIgnoreCase));
    // Output: True
  }
}
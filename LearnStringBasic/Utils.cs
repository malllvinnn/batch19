namespace LearnStringBasic;

class Utils
{
  // iterasi method
  public static void Iteration<T>(T[] values)
  {
    foreach (T value in values)
    {
      Console.WriteLine(value);
    }
  }
}
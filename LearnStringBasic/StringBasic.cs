namespace LearnStringBasic;

class StringBasic
{
  public static void Learn()
  {
    // string basic
    string helloCuy = "Hello Cuy";
    Console.WriteLine(helloCuy);
    // Output: Hello Cuy

    // repeating character
    string dashed = new string('-', 10);
    Console.WriteLine(dashed);
    // Output: ----------

    // dari char array
    char[] arr = "Hello".ToCharArray();
    Utils.Iteration(arr);
    /*  Output:
        H
        e
        l
        l
        o
    */

    string back = new string(arr);
    Console.WriteLine(back);
    // Output: Hello

    // null vs empty
    string empty = "";
    string? nullStr = null;

    Console.WriteLine(empty.Length == 0);
    // Output: True

    Console.WriteLine(empty == string.Empty);
    // Output: True

    Console.WriteLine(string.IsNullOrEmpty(empty));
    // Output: True

    Console.WriteLine(string.IsNullOrEmpty(nullStr));
    // Output: True

    Console.WriteLine(string.IsNullOrWhiteSpace(" "));
    // Output: True
  }
}
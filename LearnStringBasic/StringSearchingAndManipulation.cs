namespace LearnStringBasic;

class StringSearchingAndManipulation
{
  public static void Learn()
  {
    string text = "Hello, World!";

    // searching
    Console.WriteLine(text.Contains("World"));
    // Output: True
    Console.WriteLine(text.Contains("Cuy"));
    // Output: False

    string myName = "Muhammad Malfin Mafle Al Gazali";

    string[] myNamesArr = myName.Split(" ");
    Array.Reverse(myNamesArr);
    string myNameReverse = string.Join(" ", myNamesArr);

    Console.WriteLine(myNameReverse);
    // Output: Gazali Al Mafle Malfin Muhammad

    Console.WriteLine(myName);
    // Output: Muhammad Malfin Mafle Al Gazali

    // String Format Interpolated
    string composite = "It's {0} degrees in {1} on this {2} morning";
    string resultComposite = string.Format(composite, 29, "Salatiga", DateTime.Now.DayOfWeek);

    Console.WriteLine(resultComposite);
    // Output: It's 29 degrees in Salatiga on this Sunday morning

    Console.WriteLine(composite);
    // Output: It's {0} degrees in {1} on this {2} morning

  }
}
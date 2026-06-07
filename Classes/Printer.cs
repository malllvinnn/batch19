namespace Classes
{
  class Printer
  {
    public void Print(int value) => Console.WriteLine(value);
    public void Print(string value) => Console.WriteLine(value);
    public void Print(int a, int b) => Console.WriteLine($"{a} + {b} = {a + b}");
  }
}
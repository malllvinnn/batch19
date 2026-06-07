namespace Classes
{
  class Calculator
  {
    // Method Biasa
    public int Add(int a, int b)
    {
      return a + b;
    }

    // Expression-bodied method
    public int Multiply(int a, int b) => a * b;

    // Void method
    public void TeachYouAritmaticAdd(string yourName, int a, int b)
    {
      Console.WriteLine($"Hello {yourName}, {a} ditambah {b} menghasilkan {a + b}");
    }
  }
}
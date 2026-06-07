namespace LearnInterface
{
  class Program
  {
    public static void Main(string[] args)
    {
      // Polymorphism dengan interface
      IAnimal myDog = new Dog("Alex");
      IAnimal myCat = new Cat("Kitty");

      // My Dog
      Console.WriteLine($"Hello {myDog.Name}");
      // Output: Hello Alex

      myDog.MakeSound();
      // Output Woof

      // My Cat
      Console.WriteLine($"Hello {myCat.Name}");
      // Output: Hello Kitty

      myCat.MakeSound();
      // Output Meoww
    }
  }
}
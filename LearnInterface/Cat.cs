namespace LearnInterface
{
  // Implementasi interface
  class Cat : IAnimal
  {
    public string Name { get; set; }

    public bool IsAlive => true;

    public Cat(string name)
    {
      Name = name;
    }

    public void MakeSound()
    {
      Console.WriteLine("Meoww");
    }
  }
}
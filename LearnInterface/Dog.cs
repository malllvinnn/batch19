namespace LearnInterface
{
  // Implementasi interface
  class Dog : IAnimal
  {
    public string Name { get; set; }
    public bool IsAlive => true;

    public Dog(string name)
    {
      Name = name;
    }

    public void MakeSound()
    {
      Console.WriteLine("Woof");
    }
  }
}
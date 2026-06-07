namespace LearnInterface
{
  interface IAnimal
  {
    string Name { get; set; }
    void MakeSound();
    bool IsAlive { get; }
  }
}
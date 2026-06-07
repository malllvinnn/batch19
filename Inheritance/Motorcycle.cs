namespace Inheritance
{
  class Motorcycle : Vehicle
  {
    public int SufiksWheeler;

    public Motorcycle(string brand, string model, int sufiksWheeler)
    {
      Brand = brand;
      Model = model;
      SufiksWheeler = sufiksWheeler;
    }

    public override void Detail()
    {
      Console.WriteLine("Detail Car:");
      Console.WriteLine($"- Brand: {Brand}");
      Console.WriteLine($"- Model: {Model}");
      Console.WriteLine($"- Sufiks Wheeler: {SufiksWheeler}");
    }
  }
}
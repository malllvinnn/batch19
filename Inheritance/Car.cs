namespace Inheritance
{
  class Car : Vehicle
  {
    public string SteeringWheelPosition;
    public int SufiksWheeler;

    public Car(string brand, string model, string steeringWheelPosition, int sufiksWheeler)
    {
      Brand = brand;
      Model = model;
      SteeringWheelPosition = steeringWheelPosition;
      SufiksWheeler = sufiksWheeler;
    }

    public override void Detail()
    {
      Console.WriteLine("Detail Car:");
      Console.WriteLine($"- Brand: {Brand}");
      Console.WriteLine($"- Model: {Model}");
      Console.WriteLine($"- Steering Wheel Position: {SteeringWheelPosition}");
      Console.WriteLine($"- Sufiks Wheeler: {SufiksWheeler}");
    }
  }
}
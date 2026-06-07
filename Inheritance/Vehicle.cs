namespace Inheritance
{
  class Vehicle
  {
    public string? Brand;
    public string? Model;
    public virtual void Detail()
    {
      Console.WriteLine("Detail Vehicle:");
      Console.WriteLine($"- Brand: {Brand ?? "Nothing"}\n- Model: {Model ?? "Nothing"}");
    }
  }
}
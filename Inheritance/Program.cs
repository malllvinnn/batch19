namespace Inheritance
{
  class Program
  {
    public static void Main(string[] args)
    {
      // INHERITANCE
      Car hondaCRV = new Car("Honda", "Honda CR-V", "Right", 4);

      Console.WriteLine($"Model {hondaCRV.Model}");
      hondaCRV.Detail();
      /*  Output:
          Model Honda CR-V
          Detail Car:
          - Brand: Honda
          - Model: Honda CR-V
          - Steering Wheel Position: Right
          - Sufiks Wheeler: 4
      */

      Motorcycle hondaScoopy = new Motorcycle("Honda", "Scoopy", 2);

      Console.WriteLine($"Model {hondaScoopy.Model}");
      hondaScoopy.Detail();
      /*  Output:
          Model Scoopy
          Detail Car:
          - Brand: Honda
          - Model: Scoopy
          - Sufiks Wheeler: 2
      */

      // POLYMORPHISM IMPLEMENTATION
      static void Display(Vehicle vehicle)
      {
        Console.WriteLine($"{vehicle.Brand} {vehicle.Model}");
      }

      Car myCar = new Car("Nisan", "GTR", "Right", 4);
      Display(myCar);
      // Output: Nisan GTR

      Motorcycle myMotor = new Motorcycle("Honda", "CBR-150R", 2);
      Display(myMotor);
      // Output: Honda CBR-150R

      // CASTING
      // Upcast
      Car toyotaSupra = new Car("Toyota", "Supra", "Right", 4);
      Vehicle ts = toyotaSupra;

      Console.WriteLine($"{ts.Brand} {ts.Model}");
      // Output: Toyota Supra
      // ts.SteeringWheelPosition; ❌️

      // Is Operator
      Vehicle myVehicle = new Car("Mitsubisi", "Lancer", "Right", 4);

      if (myVehicle is Car)
        Console.WriteLine(myVehicle.Brand);
      // Output: Mitsubisi

      // Abstract Class
      FedoraLinux myLinux = new FedoraLinux("Fedora", "Linux");
      myLinux.DetailOS();
      /*  Output:
          APP DETAIL:
          - OS: Fedora
          - Kernel: Linux 7.0.11
      */

      // Hiding vs Overriding
      // Overrider
      Overrider over = new Overrider();
      BaseClass b1 = over;

      over.Foo();
      // Output: Overrider.Foo

      b1.Foo();
      // Output: Overrider.Foo

      // Hiding
      Hider hider = new Hider();
      BaseClass b2 = hider;

      hider.Foo();
      // Output: Hider.Foo

      b2.Foo();
      // Output: BaseClass.Foo
    }
  }
}
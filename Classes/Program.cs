namespace Classes
{
  class Program
  {
    public static void Main(string[] args)
    {
      // FIELD IMPLEMENTATION
      void Introduction(string name, int age)
      {
        Console.WriteLine($"Hello, Nama saya {name} usia {age}");
      }

      DetailMe detailMe = new DetailMe("Malfin", 25);

      Introduction(detailMe.Name, detailMe.Age);
      // Output: Hello, Nama saya Malfin usia 25

      detailMe.Name = "Yudi";
      Introduction(detailMe.Name, detailMe.Age);
      // Output: Hello, Nama saya Yudi usia 25

      // FIELD MODIFIER IMPLEMENTATION
      Config myAppDetail = new Config();

      // for acces readonly field (can't re-assign)
      Console.WriteLine($"- App Name: {myAppDetail.AppName}");
      // Output: - App Name: MalfinApp
      // myAppDetail.AppName = "New App"; ❌️


      // for acces static field (can re-assign)
      Console.WriteLine($"- Instance Count: {Config.InstanceCount}");
      // Output: - Instance Count: 0
      // Config.InstanceCount = 20 ❌️


      // for acces property from field private (can't setter)
      Console.WriteLine($"- Temp Path: {Config.TempPath}");
      // Output: - Temp Path: /tmp/

      // CONSTANTS
      Console.WriteLine(MathConstants.Pi);
      // Output: 3,12198
      // MathConstants.Pi = 3.21; ❌️

      Console.WriteLine(MathConstants.AppVersion);
      // Output: 1.0.0
      // MathConstants.AppVersion = "2.1.1"; ❌️

      // METHOD IMPLEMENTATION
      // Method biasa
      Calculator myCalculator = new Calculator();

      // Add (return value)
      Console.WriteLine(myCalculator.Add(11, 21));
      // Output 32

      // Mutliply (return value expresion define)
      Console.WriteLine(myCalculator.Multiply(3, 2));
      // Output: 6

      // Introductopm (void)
      myCalculator.TeachYouAritmaticAdd("Malfin", 43, 21);
      // Output: Hello Malfin, 43 ditambah 21 menghasilkan 64

      // METHOD OVERLOADING IMPLEMENTATION
      Printer myPrint = new Printer();

      myPrint.Print(2);
      // Output: 2

      myPrint.Print("Malfin");
      // Output: Malfin

      myPrint.Print(7, 2);
      // Output: 7 + 2 = 9

      // LOCAL METHOD
      void Call()
      {
        Console.WriteLine("Bro");

        string SayHello(string name)
        {
          return $"Hello {name}";
        }

        // Cuma bisa di pakai di local ✅️
        Console.WriteLine(SayHello("Malfin"));
      }


      Call();
      // Output: Bro

      // Tidak bisa ❌️
      // Console.WriteLine(Call().SayHello("Malfin"));
    }
  }
}

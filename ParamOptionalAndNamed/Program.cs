// Optional Parameter
void Greet(string name, string? greeting = "Hello")
{
    Console.WriteLine($"{greeting}, {name}");
}

Greet("Malfin");
Greet("Venrir", "Bro!");
/*  Output:
    Hello, Malfin
    Bro!, Venrir
*/
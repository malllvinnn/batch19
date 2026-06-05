// if / else if / else
void CheckAge(int age)
{
    if (age >= 35)
    {
        Console.WriteLine($"Usia {age}, Bisa jadi Presiden");
    }
    else if (age >= 21)
    {
        Console.WriteLine($"Usia {age}, Bisa Explore");
    }
    else if (age >= 18)
    {
        Console.WriteLine($"Usia {age}, Bisa Vote");
    }
    else
    {
        Console.WriteLine($"Usia {age}?... tunggu dulu");
    }
}

Random randomAge = new Random();
int rangeAge = randomAge.Next(1, 100);

CheckAge(rangeAge);
// Output: Usia 30, Bisa Explore

// Statement
// Base Array Data Dummy
string[] names = { "Malfin", "Venrir", "Bule" };

// Loop For
for (int i = 0; i < names.Length; i++)
{
    Console.WriteLine($"{i + 1} {names[i]}");
}
/*  Output:
    1 Malfin
    2 Venrir
    3 Bule
*/

// Loop Foreach
foreach (string name in names)
{
    Console.WriteLine($"Hello {name}");
}
/*  Output:
    Hello Malfin
    Hello Venrir
    Hello Bule
*/

foreach (char c in "Berangkat")
{
    Console.WriteLine(c);
}
/*  Output:
    B
    e
    r
    a
    n
    g
    k
    a
    t
*/

// JUMP STATEMENT DAN LAINNYA
// break keluar dari loop
for (int i = 0; i < 10; i++)
{
    if (i == 5) break;
    Console.WriteLine(i);
}
/*  Output:
    0
    1
    2
    3
    4
*/

// continue - skip iterasi tertentu, lanjut ke berikutnya
for (int i = 0; i < 10; i++)
{
    if (i % 2 == 0) continue;
    Console.WriteLine(i);
}
/*  Output:
    1
    3
    5
    7
    9
*/

// return method
decimal ToPercent(decimal d)
{
    return d * 100m;
}

Console.WriteLine(ToPercent(15));
// Output: 1500

// throw lempar exception
void ValidateName(string? name)
{
    try
    {
        if (name == null)
        {
            throw new ArgumentNullException(nameof(name));
        }
        else
        {
            Console.WriteLine(name);
        }
    }
    catch (Exception e)
    {

        Console.WriteLine(e.Message);
    }

}

ValidateName(null);
/*  Output:
    Value cannot be null. (Parameter 'name')
*/

ValidateName("Malfin");
// Output: Malfin

// using statement auto dispose resource
using (var file = new StreamReader("file.txt"))
{
    string content = file.ReadToEnd();
    Console.WriteLine(content);
}
// Output: Lorem ipsum dolor sit amet, consectetur adipiscing elit.
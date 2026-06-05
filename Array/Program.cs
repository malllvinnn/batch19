// DEKLARASI ARRAY & AKSES
// Deklarasi 5 arrays
char[] vowels = new char[5];

// assign array
vowels[0] = 'a';
vowels[1] = 'i';
vowels[2] = 'u';
vowels[3] = 'e';
vowels[4] = 'o';

// iteration array for output on console
for(int i = 0; i < vowels.Length; i++)
{
    Console.WriteLine(vowels[i]);
}
/*  Output:
    a
    i
    u
    e
    o
*/

// ARRAY INITILATION
// Method Checker
void HandleArrayChecker<T>(T[] arrays)
{
    foreach(T array in arrays)
    {
        Console.WriteLine(array);
    }
}

// Explisit
string[] names1 = new string[] {"Malfin", "Venrir", "Bule"};
HandleArrayChecker(names1);
/*  Output:
    Malfin
    Venrir
    Bule
*/

// Lebih Singkat (Best Practice)
string[] names2 = {"Mafle", "Bin", "Paricull"};
HandleArrayChecker(names2);
/*  Output:
    Mafle
    Bin
    Paricull
*/

// Pakai Var
var names3 = new[] {"Yuki", "Yobel", "Nana"};
HandleArrayChecker(names3);
/*  Output:
    Yuki
    Yobel
    Nana
*/

// INDICES DAN RANGE
// Base Array
string[] names4 = {"Malfin", "Bule", "Venrir", "Mafle", "Bian", "Yuki", "Alex"};

// Indices
string last = names4[^1]; // Pertama dari yang terakhir
Console.WriteLine($"Last: {last}");
// Output: "Last: Alex"

string secondLast = names4[^2]; // Kedua dari yang terakhir
Console.WriteLine($"Second Last: {secondLast}");
// Output: "Second Last: Yuki"

// Range
string[] rangeFirst = names4[..3];
HandleArrayChecker(rangeFirst);
/*  Output:
    Malfin
    Bule
    Venrir
*/

string[] rangeLast = names4[5..];
HandleArrayChecker(rangeLast);
/*  Output:
    Yuki
    Alex
*/

string[] rangeMiddle = names4[2..5];
HandleArrayChecker(rangeMiddle);
/*  Output:
    Venrir
    Mafle
    Bian
*/

string[] rangeLastTwo = names4[^2..];
HandleArrayChecker(rangeLastTwo);
/*  Output:
    Yuki
    Alex
*/
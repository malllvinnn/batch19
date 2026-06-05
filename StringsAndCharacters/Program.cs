// STRING TYPE
string name = "Malfin";
string upper = name.ToUpper();

Console.WriteLine(name);
Console.WriteLine(upper);
/* Output:
 Malfin
 MALFIN
*/

string a = "test";
string b = "test";
Console.WriteLine(a == b);
// Output: True

// VERBATIM STRING
// Tanpa Verbatim
string path1 = "C:\\Users\\Malfin\\Documents";
Console.WriteLine(path1);
// Output: C:\Users\Malfin\Documents

string path2 = @"C:\Users\Malfin\Documents";
Console.WriteLine(path2);
// Output: C:\Users\Malfin\Documents

// Keduanya Match
Console.WriteLine(path1 == path2);
// Output: True

// Multi Line
string multiLine = @"Baris Pertama
Baris Kedua
Baris Ketiga
";
Console.WriteLine(multiLine);
/*  Output:
    Baris Pertama
    Baris Kedua
    Baris Ketiga
*/
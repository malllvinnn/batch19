// Null Coalescing assignment
string? name1 = null;
name1 ??= "Default1";

Console.WriteLine(name1);
// Output: Default1

// Null Coalescing Operator
string? name2 = null;

Console.WriteLine(name2 ?? "Default2");
// Output: Default2
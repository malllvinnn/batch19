static void Foobar(int n)
{
    for(int x = 1; x <= n; x++)
    {
        if (x % 3 == 0 && x % 5 == 0)
        {
            Console.WriteLine("Foobar");
        }
        else if (x % 3 == 0)
        {
            Console.WriteLine("Foo");
        }
        else if (x % 5 == 0)
        {
            Console.WriteLine("Bar");
        }
        else
        {
            Console.WriteLine(x);
        }
    }
}

Foobar(20); 
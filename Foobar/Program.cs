void Foobar(int n)
{
    for (int x = 1; x <= n; x++)
    {
        if (x % 3 == 0 && x % 5 == 0 && x % 7 == 0)
        {
            Console.WriteLine("foobarjazz");
        }
        else if (x % 5 == 0 && x % 7 == 0)
        {
            Console.WriteLine("barjazz");
        }
        else if (x % 3 == 0 && x % 7 == 0)
        {
            Console.WriteLine("foojazz");
        }
        else if (x % 3 == 0 && x % 5 == 0)
        {
            Console.WriteLine("foobar");
        }
        else if (x % 3 == 0)
        {
            Console.WriteLine("foo");
        }
        else if (x % 5 == 0)
        {
            Console.WriteLine("bar");
        }
        else if (x % 7 == 0)
        {
            Console.WriteLine("jazz");
        }
        else
        {
            Console.WriteLine(x);
        }
    }
}

Foobar(200);
void Foobar(int n)
{
    for(int x = 1; x <= n; x++)
    {
        if (x % 3 == 0 && x % 5 == 0)
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
        else
        {
            Console.WriteLine(x);
        }
    }
}

Foobar(20); 
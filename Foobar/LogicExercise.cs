namespace Foobar;

class LogicExercise
{
    public void AddRule(int n)
    {
        for (var x = 1; x <= n; x++)
            if (x % 3 == 0 && x % 5 == 0 && x % 7 == 0)
                Console.WriteLine("foobarjazz");
            else if (x % 5 == 0 && x % 7 == 0)
                Console.WriteLine("barjazz");
            else if (x % 3 == 0 && x % 7 == 0)
                Console.WriteLine("foojazz");
            else if (x % 3 == 0 && x % 5 == 0)
                Console.WriteLine("foobar");
            else if (x % 9 == 0)
                Console.WriteLine("huzz");
            else if (x % 4 == 0)
                Console.WriteLine("baz");
            else if (x % 3 == 0)
                Console.WriteLine("foo");
            else if (x % 5 == 0)
                Console.WriteLine("bar");
            else if (x % 7 == 0)
                Console.WriteLine("jazz");
            else
                Console.WriteLine(x);
    }
}
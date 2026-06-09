namespace NestedType
{
    public class TopLevel
    {
        private static int _secret = 42;

        class Nested  // private nested class
        {
            public void RevealSecret()
            {
                Console.WriteLine(_secret); // ✅ bisa akses private!
            }
        }

        public void DoSomething()
        {
            new Nested().RevealSecret(); // 42
        }
    }
}
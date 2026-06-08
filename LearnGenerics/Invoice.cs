namespace LearnGenerics
{
    class Invoice : IPrintable
    {
        private string _invoice;

        public Invoice(string invoice)
        {
            _invoice = invoice;
        }

        public void Print()
        {
            Console.WriteLine($"Invoice: {_invoice}");
        }
    }
}
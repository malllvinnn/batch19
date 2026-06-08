namespace LearnGenerics
{
    class Report : IPrintable
    {
        private string _title;

        public Report(string title)
        {
            _title = title;
        }

        public void Print()
        {
            Console.WriteLine($"Title: {_title}");
        }
    }
}
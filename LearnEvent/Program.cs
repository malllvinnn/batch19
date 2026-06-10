namespace LearnEvent
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Usage Event
            Stock stock = new Stock("THPW");
            stock.Price = 27.10M;

            // Subcribe to Event
            stock.PriceChanged += stock_PriceChanged;

            stock.Price = 31.59M;

            void stock_PriceChanged(object sender, PriceChangeEventArgs e) // subcriber method
            {
                if ((e.NewPrice - e.LastPrice) / e.LastPrice > 0.1M)
                {
                    Console.WriteLine("Alert, 10% stock price increase!");
                }
            }

            // Output: Alert, 10% stock price increase!
        }
    }
}


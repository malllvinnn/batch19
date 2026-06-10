namespace LearnEvent
{
    // 1. EventArgs subclass — data yang dibawa event
    class PriceChangeEventArgs
    {
        public readonly decimal LastPrice;
        public readonly decimal NewPrice;

        public PriceChangeEventArgs(decimal lastPrice, decimal newPrice)
        {
            LastPrice = lastPrice;
            NewPrice = newPrice;
        }
    }
}
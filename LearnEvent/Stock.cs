namespace LearnEvent
{
    class Stock
    {
        private string _symbol;
        private decimal _price;

        public Stock(string symbol)
        {
            _symbol = symbol;
        }

        // 2. Event dengan generic EventHandler<T>
        public event EventHandler<PriceChangeEventArgs> PriceChanged;

        // 3. Protect virtual "On" Method
        protected virtual void OnPriceChanged(PriceChangeEventArgs e)
        {
            PriceChanged?.Invoke(this, e);
        }

        public decimal Price
        {
            get => _price;
            set
            {
                if (_price == value) return; // exit if prixe hasn't changed

                decimal oldPrice = _price;
                _price = value;

                OnPriceChanged(new PriceChangeEventArgs(oldPrice, _price)); // raise the event
            }
        }
    }
}
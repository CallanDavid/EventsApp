using System.ComponentModel;
using System.Threading;

namespace EventsApp
{
    // Define the delegate that will be used for the event
    public delegate void StockPriceChangedHandler(string message);

    // Define the Stock class which includes the event system
    public class Stock
    {
        // Declare the event using the delegate
        // Private field to store the stock price
        // Private field to store the threshold
        //TODO
        public event StockPriceChangedHandler OnStockPriceChanged;

        private decimal _price;
        private decimal _threshold;

        // Property to get and set the stock price
        public decimal Price 
        {
            // Set the new price
            // Raise the event if the price drops below the threshold
            //TODO
                get { return _price; }
            set
            {
                _price = value;
                if (_price < _threshold)
                {
                    RaiseStockPriceChangedEvent($"Stock price increased to {value}");
                }
            }
        }
       
        // Property to get and set the alert threshold
        public decimal Threshold
        {
            //TODO
            get { return _threshold; }
            set 
            {
                _threshold = value;
            }
        }

        // Method to raise the stock price changed event
        protected virtual void RaiseStockPriceChangedEvent(string message)
        {
            // Invoke the event
            //TODO
            OnStockPriceChanged?.Invoke(message);
        }
    }


    // Define the subscriber class which reacts to the event
    public class StockAlert
    {
        // Method that handles the event and prints a message to the console
        //TODO
        public void OnStockPriceChanged(string message)
        {
            Console.WriteLine("Stock Alert: Stock price is below threshold!");
        }
    }

    // Program class to simulate the stock price changes and test the event system
    class Program
    {
        static void Main(string[] args)
        {
            // Create instances of Stock and StockAlert
            //TODO
            Stock stock = new Stock();
            StockAlert stockAlert = new StockAlert();

            // Subscribe to the stock price changed event
            //TODO
            stock.OnStockPriceChanged += stockAlert.OnStockPriceChanged;

            // Set the alert threshold
            //TODO
            stock.Threshold = 120;
            // Simulate stock price changes
            //TODO
            stock.Price = int.Parse(Console.ReadLine());
            // Wait for user input to close the console
            //TODO
            Console.ReadLine();
        }
    }
}


namespace EventsApp
{
    public delegate void TemperatureChangeHandler(string message);

    public class TemperatureMonitor
    {
        public event TemperatureChangeHandler OnTemperatureChange;

        private int _temperature;
        public int Temperature { get { return _temperature; }
            set
            {
                _temperature = value;   
                if(_temperature > 30)
                {
                    // RAISE EVENT
                    RaiseTemperatureChangeEvent("Temperature is above threshold");
                }
            }
        }
        protected virtual void RaiseTemperatureChangeEvent(string message)
        {
            OnTemperatureChange?.Invoke(message);       // '?' means it could potentially be 0
        }
    }

    public class TemperatureAlert
    {
        public void OnTemperatureChange(string message)
        {
            Console.WriteLine($"Alert: {message}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TemperatureMonitor monitor = new TemperatureMonitor();
            TemperatureAlert alert = new TemperatureAlert();
            monitor.OnTemperatureChange += alert.OnTemperatureChange;

            monitor.Temperature = 20;
            Console.WriteLine("Please enter the temperature...");
            monitor.Temperature = int.Parse(Console.ReadLine());
            Console.ReadLine();
        }
    }
}

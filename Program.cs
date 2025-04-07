using System.ComponentModel;
using System.Threading;

namespace EventsApp
{
    // Using the Generic Delegate EventHandler<TEventArgs>

    public delegate void TemperatureChangeHandler(string message);

    public class TemperatureChangedEventArgs: EventArgs
    {
        // Property holding the temperature value
        public int Temperature { get; }
        // Constructor
        public TemperatureChangedEventArgs(int temperature)
        {
            Temperature = temperature;
        }
    }

    public class TemperatureMonitor
    {
        public event EventHandler<TemperatureChangedEventArgs> TemperatureChanged;

        public event TemperatureChangeHandler OnTemperatureChange;

        private int _temperature;
        public int Temperature
        {
            get { return _temperature; }
            set
            {
                if (_temperature != value)
                {
                    _temperature = value;
                    // RAISE EVENT
                    OnTemperatureChanged(new TemperatureChangedEventArgs(_temperature));
                }
            }
        }
        protected virtual void OnTemperatureChanged(TemperatureChangedEventArgs e)
        {
            // letting every subscriber know
            TemperatureChanged?.Invoke(this, e);       // '?' means it could potentially be 0
        }
    }

    //Subscriber

    public class TemperatureAlert
    {
        public void OnTemperatureChange(object sender, TemperatureChangedEventArgs e)
        {
            Console.WriteLine($"Alert: temperature is {e.Temperature} \tSender is {sender}");
        }
    }
    //   Subscriber #2
    public class TempCoolingAlert
    {
        public void OnTemperatureChange(object sender, TemperatureChangedEventArgs e)
        {
            Console.WriteLine($"TEMP COOLING ALERT: temperature is {e.Temperature} \tSender is {sender}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TemperatureMonitor monitor = new TemperatureMonitor();
            TemperatureAlert alert = new TemperatureAlert();
            TempCoolingAlert alert2 = new TempCoolingAlert();
            monitor.TemperatureChanged += alert.OnTemperatureChange;
            monitor.TemperatureChanged += alert2.OnTemperatureChange;

            monitor.Temperature = 20;
            Console.WriteLine("Please enter the temperature...");
            monitor.Temperature = int.Parse(Console.ReadLine());
            Console.ReadLine();
        }
    }
}


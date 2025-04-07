namespace EventsApp
{
    public delegate void Notify(string message);

    public class EventPublisher
    {
        /*
            The 'On' prefix makes it immediately clear that the method is associated to an event.
            It signifies that the method is not just a regular method but one that is called when a specific event occurs.
         */
        public event Notify OnNotify;

        public void RaiseEvent(string message)
        {
            // Invoke the event if there are any subscribers
            OnNotify?.Invoke(message);
        }
    }

    public class EventSubscriber
    {
        public void OnEventRaised(string message)
        {
            Console.WriteLine("Event received: " + message);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            EventPublisher publisher = new EventPublisher();
            EventSubscriber subscriber = new EventSubscriber();
            publisher.OnNotify += subscriber.OnEventRaised;

            publisher.RaiseEvent("test");

            Console.ReadLine();
        }
    }
}

// Exercise 2: Event Scheduler

// 1. Create a class named 'Event' with properties 'Name', 'Location', 'DateTime'.
public class Event
{
    public string Name { get; set; }
    public string Location { get; set; }
    public DateTime DateTime { get; set; }
}

// 2. Create a class EventScheduler with a list of Event. Add methods to ScheduleEvent, CancelEvent, and GetUpcomingEvents.
public class EventScheduler
{
    private List<Event> events = new List<Event>();

    public void ScheduleEvent(Event newEvent)
    {
        // Prevent double-booking
        if (IsDoubleBooking(newEvent))
        {
            Console.WriteLine("Double-booked. The event could not be scheduled.");
            return;
        }

        events.Add(newEvent);
        Console.WriteLine("Schedule success.");
    }

    public void CancelEvent(Event eventToCancel)
    {
        events.Remove(eventToCancel);
        Console.WriteLine("Cancel success.");
    }

    public List<Event> GetUpcomingEvents()
    {
        DateTime currentDateTime = DateTime.Now;
        List<Event> upcomingEvents = events.Where(e => e.DateTime > currentDateTime).OrderBy(e => e.DateTime).ToList();
        Console.WriteLine("Upcoming Events:");
        foreach (Event upcomingEvent in upcomingEvents)
        {
            Console.WriteLine("Name: " + upcomingEvent.Name);
            Console.WriteLine("Location: " + upcomingEvent.Location);
            Console.WriteLine("DateTime: " + upcomingEvent.DateTime.ToString());
        }
        return upcomingEvents;
    }

    // 3. Implement a feature to prevent double-booking, where two events are scheduled for the exact same time.
    private bool IsDoubleBooking(Event newEvent)
    {
        return events.Any(e => e.DateTime == newEvent.DateTime);
    }
}

class Program
{
    // Test: generate several schedulers and and see upcoming events then canceling.
    static void Main()
    {
        // 1
        Console.WriteLine("Add first event.");
        EventScheduler eventScheduler = new EventScheduler();
        Event event1 = new Event
        {
            Name = "Event 1",
            Location = "Location 1",
            DateTime = new DateTime(2023, 6, 26, 17, 0, 0)
        };
        eventScheduler.ScheduleEvent(event1);
        Console.WriteLine("");

        // 2
        Console.WriteLine("Add Second event.");
        Event event2 = new Event
        {
            Name = "Event 2",
            Location = "Location 2",
            DateTime = new DateTime(2023, 6, 27, 17, 30, 0)
        };
        eventScheduler.ScheduleEvent(event2);
        Console.WriteLine("");

        // 3
        Console.WriteLine("Add third event but double booking.");
        Event event3 = new Event
        {
            Name = "Event 3",
            Location = "Location 3",
            DateTime = new DateTime(2023, 6, 27, 17, 30, 0)
        };
        eventScheduler.ScheduleEvent(event3);
        Console.WriteLine("");

        // 4
        Console.WriteLine("Get Upcoming Events");
        eventScheduler.GetUpcomingEvents();
        Console.WriteLine("");

        // 5
        Console.WriteLine("Cancel Event");
        eventScheduler.CancelEvent(event2);
        Console.WriteLine("");

        // 6
        Console.WriteLine("Get Upcoming Events the second time");
        eventScheduler.GetUpcomingEvents();
        Console.WriteLine("");

    }
}
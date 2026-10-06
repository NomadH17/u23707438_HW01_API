namespace u23707438_HW01_API.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventTitle { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string TicketPrice { get; set; } = string.Empty;
    }
}
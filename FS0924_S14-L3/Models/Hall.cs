namespace FS0924_S14_L3.Models
{
    public class Hall
    {
        public string? Name { get; set; }
        public List<Ticket>? TicketsList { get; set; }
        public int ReducedTicketsCount = 0;
    }
}

namespace FS0924_S14_L3.Models
{
    public class Gestional
    {
        public List<Ticket> NorthHall { get; set; } = [];
        public List<Ticket> EastHall { get; set; } = [];
        public List<Ticket> SouthHall { get; set; } = [];

        public string GetTicketType(bool val)
        {
            return val ? "text-warning" : "text-black";
        }
    }
}

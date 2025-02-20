namespace FS0924_S14_L3.Models
{
    public class Gestional
    {
        public Hall? NorthHall { get; set; }
        public Hall? EastHall { get; set; }
        public Hall? SouthHall { get; set; }

        public string GetTicketType(bool val)
        {
            return val ? "text-warning" : "text-black";
        }
    }
}

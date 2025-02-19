namespace FS0924_S14_L3.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Hall { get; set; }
        public bool? IsReduced { get; set; } = false;
    }
}

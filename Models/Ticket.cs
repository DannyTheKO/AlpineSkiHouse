namespace AlpineSkiHouse.Models
{
    public class Ticket
    {
        public required int Id { get; set; }
        
        public required string CustomerName { get; set; }
        
        public required string RoomNumber { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }
    }
}

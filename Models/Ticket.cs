using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlpineSkiHouse.Models
{
    public class Ticket
    {
        [Column("id") ,Key]
        public required int Id { get; set; }

        [Column("customer_name")]
        public required string CustomerName { get; set; }

        [Column("room_number")]
        public required string RoomNumber { get; set; }

        [Column("check_in")]
        public DateTime CheckIn { get; set; }
        
        [Column("check_out")]
        public DateTime CheckOut { get; set; }
    }
}

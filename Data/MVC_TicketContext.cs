using Microsoft.EntityFrameworkCore;
using AlpineSkiHouse.Models;

namespace AlpineSkiHouse.Data
{
	public class MVC_TicketContext : DbContext
	{
		public MVC_TicketContext(DbContextOptions<MVC_TicketContext> options) : base(options)
		{

		}
		public DbSet<Ticket> Ticket { get; set; }

	}
}

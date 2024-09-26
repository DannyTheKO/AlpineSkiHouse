using AlpineSkiHouse.Models;
using Microsoft.EntityFrameworkCore;

namespace AlpineSkiHouse.Data
{
	public class MVC_TicketContext : DbContext
	{
		public MVC_TicketContext(DbContextOptions<MVC_TicketContext> options) : base(options)
		{

		}
		public DbSet<Ticket> Tickets { get; set; }

	}
}

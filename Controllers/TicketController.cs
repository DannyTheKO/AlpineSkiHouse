using Microsoft.AspNetCore.Mvc;
using AlpineSkiHouse.Models;
using AlpineSkiHouse.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Threading.Tasks;
using System.Linq;

namespace AlpineSkiHouse.Controllers
{
    public class TicketController : Controller
    {
        private readonly MVC_TicketContext _context;

        public TicketController (MVC_TicketContext context)
        {
            _context = context;
        }

        // GET: Ticket
        public async Task<IActionResult> Index()
        {
            if (_context == null)
            {
                return Problem("Entity set 'MVC_TicketContext.Ticket' is null.");
            }
            return View(await _context.Ticket.ToListAsync());
        }

        // GET: Ticket/Create
        public IActionResult Create()
        {
            return View("Create");
        }

        // POST: Ticket/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id", "CustomerName", "RoomNumber", "CheckIn", "CheckOut")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(ticket);
        }

        // GET: Ticket/Edit/{id}
        public async Task<IActionResult> Edit(int? id)
        {
            if ( id == null )
            {
                return NotFound();
            }

            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Ticket/Edit/{id}
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id", "CustomerName", "RoomNumber", "CheckIn", "CheckOut")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                
                catch (DBConcurrencyException)
                {
                    var existingTicket = await _context.Ticket.FindAsync(ticket.Id);
                    if (existingTicket == null)
                    {
                        return NotFound();
                    }

                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(ticket);
        }

        // GET: Ticket/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Ticket/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket != null)
            {
                _context.Ticket.Remove(ticket);
                await _context.SaveChangesAsync();
            }

            else
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

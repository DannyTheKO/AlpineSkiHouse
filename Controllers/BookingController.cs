using Microsoft.AspNetCore.Mvc;
using AlpineSkiHouse.Models;

namespace AlpineSkiHouse.Controllers
{
    public class BookingController : Controller
    {
        // Create a data of type Ticket
        static List<Ticket> tickets = new List<Ticket>
        {
            new Ticket { Id = 1, CustomerName = "Danny Vetiso", RoomNumber = "A102" , CheckIn = GetRandomDateTime(), CheckOut = GetRandomDateTime()},
            new Ticket { Id = 2, CustomerName = "Log Rosswell", RoomNumber = "B202" , CheckIn = GetRandomDateTime(), CheckOut = GetRandomDateTime()},
            new Ticket { Id = 3, CustomerName = "Tunic (The Fox)", RoomNumber = "C125" , CheckIn = GetRandomDateTime(), CheckOut = GetRandomDateTime()}
        };

        // Random Date Function
        static DateTime GetRandomDateTime()
        {
            Random random = new Random();
            DateTime start = DateTime.Now.AddMonths(-1); // Start date (1 month ago)
            int range = (DateTime.Now - start).Days; // Range of days between start date and now
            return start.AddDays(random.Next(range)); // Add a random number of days to the start date
        }

        public IActionResult Index()
        {
            return View("Index", tickets);
        }

        // Create
        public IActionResult Create()
        {
            return View("Create");
        }

        // POST Request for Create
        [HttpPost]
        public IActionResult Create([Bind("Id", "CustomerName", "RoomNumber", "CheckIn", "CheckOut")] Ticket ticket)
        {
            tickets.Add(ticket);
            return RedirectToAction("Index");
        }

        // Read
        public IActionResult Read()
        {
            return View("Read");
        }

        // Edit
        public IActionResult Edit(int id)
        {
            Ticket t = tickets.SingleOrDefault(ts => ts.Id == id);
            if (t != null)
                return View(t);
            else
                return View("Index", tickets);
        }

        // POST Request for Edit
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id", "CustomerName", "RoomNumber", "CheckIn", "CheckOut")] Ticket ticket)
        {
            Ticket t = tickets.SingleOrDefault(ts => ts.Id == id);
            if (t != null)
            {
                //t.Id = ticket.Id;
                t.CustomerName = ticket.CustomerName;
                t.RoomNumber = ticket.RoomNumber;
                t.CheckIn = ticket.CheckIn;
                t.CheckOut = ticket.CheckOut;
            }
            else
                return NotFound();

            return RedirectToAction("Index");
        }

        // Delete
        public IActionResult Delete(int id)
        {
            Ticket t = tickets.SingleOrDefault(ts => ts.Id == id);
            if (t != null)
            {
                tickets.Remove(t);
            }
            else
                NotFound();

            return RedirectToAction("Index");
        }


    }
}

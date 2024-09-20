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

        // Read
        public IActionResult Read()
        {
            return View("Read");
        }

        // Update
        public IActionResult Update()
        {
            return View("Update");
        }

        // Remove
        public IActionResult Remove()
        {
            return View("Remove");
        }


    }
}

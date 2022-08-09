using BaggageTracking.Data;
using BaggageTracking.Models;
using BaggageTracking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BaggageTracking.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BaggageDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, BaggageDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TrackingList(string ticketCode)
        {
            if(string.IsNullOrEmpty(ticketCode))
            {
                TempData["Messenge"] = "Ticket code is required.";
                return RedirectToAction(nameof(Index));
            }

            // Comes from data Api 
            var ticket = _dbContext.Tickets
                .Include(x=>x.Baggage)
                .Include(x => x.Baggage.Landed)
                .Include(x => x.Baggage.IsOut)
                .Include(x => x.Baggage.Loading)
                .Include(x=>x.Baggage.OutPlatform)
                .FirstOrDefault(x => x.FlyCode.ToLower() == ticketCode.ToLower());

            if (ticket == null)
            {
                TempData["Messenge"] = "Ticket not found";
                return RedirectToAction(nameof(Index));
            }

            DateTime time = ticket.FlyDate.AddHours(-4);

            if (time > DateTime.Now)
            {
                TempData["Messenge"] = "Wait for the tickets to be checked.";
                return RedirectToAction(nameof(Index));
            }

            var listVM = new TrackingListVM
            {
                Baggage = ticket.Baggage,
                Platform = ticket.Baggage?.OutPlatform 
            };

            return View(listVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
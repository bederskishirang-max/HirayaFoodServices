using HirayaFoodServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HirayaFoodServices.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public record Specialty(string Img, string Title, string Desc);

        public IActionResult Index()
        {
            var specialties = new List<Specialty>
            {
                new("~/img/menu-pork-lechon.jpg",  "Lechon & Pork Trays",   "Lechon belly, BBQ, humba, sisig & more."),
                new("~/img/menu-food-tray.jpg",    "Food Trays",            "Pancit, lumpia, baked mac, chicken trays."),
                new("~/img/menu-lechon-belly.jpg", "Lechon Belly Packages", "Small, medium & large with side dishes."),
            };
            return View(specialties);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

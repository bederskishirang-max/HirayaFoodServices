using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HirayaFoodServices.Controllers
{
    public class PackagesViewModel
    {
        public record BellyTier(string Tier, decimal Price, string Kg, string Pax);
        public record FoodPackage(string Name, decimal Price, List<string> Includes);

        public List<BellyTier> LechonBelly { get; set; }
        public List<FoodPackage> FoodPackages { get; set; }
    }


    public class PackagesController : Controller
    {

        public IActionResult Index()
        {
            var vm = new PackagesViewModel
            {
                LechonBelly = new()
                {
                    new("SMALL", 4500, "3kg", "8 - 10 pax"),
                    new("MEDIUM", 6500, "5kg", "10 - 15 pax"),
                    new("LARGE", 7500, "5kg", "15 - 20 pax"),
                },
                FoodPackages = new()
                {
                    new("Package 1", 13700, new() { "Lechon (Small) 15kg cooked", "Lumpia 1 tray", "Chopsuey 1 tray", "Bam-e 1 tray", "Calamare 1 tray", "Paklay 1 tray", "Watermelon 1 tray" }),
                    new("Package 2", 11700, new() { "Lechon (Small) 15kg cooked", "Lumpia 1/2 (50pcs)", "Chopsuey 1/2 tray", "Bam-e 1/2 tray", "Calamare 1/2 tray", "Paklay 1/2 tray", "Watermelon 1/2 tray" }),
                    new("Package 3", 16500, new() { "Lechon 35-38kg live weight", "Shanghai Rolls 100pcs", "Choose 1: Bam-e / Chopsuey", "Choose 2 chicken trays (2.5kg)", "Choose 2 pork/seafood trays", "FREE: Watermelon, Dinuguan, Adobo Ilogon" }),
                    new("Package 4", 14000, new() { "Lechon 35-38kg live weight", "Shanghai Rolls 50pcs", "Choose 1: 1/2 Bam-e / Chopsuey", "Choose 2 chicken half trays", "Choose 2 pork/seafood half trays", "FREE: Watermelon, Dinuguan, Adobo Ilogon" }),
                },
            };
            return View(vm);
        }
    }
}

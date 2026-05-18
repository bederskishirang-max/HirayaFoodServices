using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HirayaFoodServices.Controllers
{
    public class MenuController : Controller
    {
        public record PriceItem(string Name, decimal Price);
        public record PriceList(string Title, string Image, List<PriceItem> Items);

        public IActionResult Index()
        {
            var lists = new List<PriceList>
            {
                new("FOOD TRAYS", "~/img/menu-food-tray.jpg", new()
                {
                    new("100 pcs. Shanghai Rolls", 700), new("100 pcs. Lumpia Tauge", 700), new("100 pcs. Vegetable Lumpia", 700),
                    new("Chop Suey", 900), new("Bam-e", 900), new("Special Bihon", 900), new("Special Pancit Canton", 900),
                    new("Spaghetti", 900), new("Baked Mac", 1000), new("Chicken Lumpia", 900), new("Buttered Cordon Bleu", 1100),
                    new("Chicken Embutido", 1100), new("Chicken Fillet", 1100), new("Chicken Afritada", 1000),
                    new("Chicken Curry", 1000), new("Chicken Finger", 1100), new("Buffalo Wings", 1000), new("Battered Chicken", 1000),
                }),
                new("PORK & SEAFOOD", "~/img/menu-pork-lechon.jpg", new()
                {
                    new("50 sticks Pork BBQ", 1250), new("Pork Menudo", 1250), new("Pork Afritada", 1250), new("Pork Calderita", 1250),
                    new("Pork Sisig", 1250), new("Humba", 1250), new("Sweet & Sour Pork Bola-bola", 1250), new("Pork Chop Guisado", 1250),
                    new("Pork Steak", 1250), new("Sinuglaw", 1250), new("Grilled Bangus", 1200), new("Grilled Tuna Panga", 1200),
                    new("Garlic Shrimp", 1350), new("Calamare", 1350), new("Fish Fillet", 1200), new("Fish Sweet & Sour", 1200),
                    new("Mixed Seafoods", 1350), new("Guso", 650), new("Lato", 650),
                }),
                new("DESSERT IN A PARTY TRAY", null, new()
                {
                    new("Buko Pandan", 900), new("Mango Tapioca", 900), new("Mango Float", 1000), new("Macaroni Salad", 1000),
                    new("Fruit Salad", 1000), new("Fruitmac Salad", 900), new("Chickenmac Salad", 1000), new("Vegi Salad (w/ crabmeat & corn)", 1000),
                }),
            };
            return View(lists);
        }
    }
}

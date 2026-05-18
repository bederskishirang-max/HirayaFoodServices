using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HirayaFoodServices.Models
{
    public class FoodSourceFormModel
    {
        public int? Id { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; }

        [Required, StringLength(80)]
        public string Category { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Range(0, 1000000)]
        public decimal Price { get; set; }

        public IFormFile Image { get; set; }
    }

    public class AdminIndexViewModel
    {
        public List<FoodSource> Items { get; set; } = new();
        public FoodSourceFormModel Input { get; set; } = new();
        public int? EditingId { get; set; }
        public string StatusMessage { get; set; }
    }
}

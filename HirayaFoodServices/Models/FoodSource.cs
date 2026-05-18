using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HirayaFoodServices.Models
{
    public class FoodSource
    {
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; }

        [Required, StringLength(80)]
        public string Category { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        // Stored relative path, e.g. "/uploads/abc.jpg".
        // The controller turns this into an absolute URL on responses.
        public string ImageUrl { get; set; }
    }
}

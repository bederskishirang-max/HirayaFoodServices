using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HirayaFoodServices.Models;
using Microsoft.EntityFrameworkCore;



namespace HirayaFoodServices.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<FoodSource> FoodSources { get; set; }

        protected override void OnModelCreating(ModelBuilder b)
        {
            b.Entity<FoodSource>().Property(x => x.Price).HasColumnType("decimal(18,2)");
        }
    }
}

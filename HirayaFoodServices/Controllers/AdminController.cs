using HirayaFoodServices.Models;
using HirayaFoodServices.Data;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HirayaFoodServices.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;

        public AdminController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        // GET /Admin  or  /Admin?edit=5
        public async Task<IActionResult> Index(int? edit)
        {
            var vm = new AdminIndexViewModel
            {
                Items = await _db.FoodSources.OrderByDescending(x => x.Id).ToListAsync(),
                StatusMessage = TempData["StatusMessage"] as string,
            };

            if (edit.HasValue)
            {
                var f = await _db.FoodSources.FindAsync(edit.Value);
                if (f != null)
                {
                    vm.EditingId = f.Id;
                    vm.Input = new FoodSourceFormModel
                    {
                        Id = f.Id,
                        Name = f.Name,
                        Category = f.Category,
                        Description = f.Description,
                        Price = f.Price,
                    };
                }
            }
            return View(vm);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FoodSourceFormModel Input)
        {
            if (!ModelState.IsValid) return await Index(null);

            var f = new FoodSource
            {
                Name = Input.Name,
                Category = Input.Category,
                Description = Input.Description,
                Price = Input.Price,
                ImageUrl = await SaveImageAsync(Input.Image),
            };
            _db.FoodSources.Add(f);
            await _db.SaveChangesAsync();
            TempData["StatusMessage"] = $"Created \"{f.Name}\".";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(FoodSourceFormModel Input)
        {
            if (!Input.Id.HasValue) return RedirectToAction(nameof(Index));
            var f = await _db.FoodSources.FindAsync(Input.Id.Value);
            if (f == null) return RedirectToAction(nameof(Index));

            f.Name = Input.Name; f.Category = Input.Category;
            f.Description = Input.Description; f.Price = Input.Price;
            var newImg = await SaveImageAsync(Input.Image);
            if (newImg != null) f.ImageUrl = newImg;

            await _db.SaveChangesAsync();
            TempData["StatusMessage"] = $"Updated \"{f.Name}\".";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var f = await _db.FoodSources.FindAsync(id);
            if (f != null)
            {
                _db.FoodSources.Remove(f);
                await _db.SaveChangesAsync();
                TempData["StatusMessage"] = $"Deleted \"{f.Name}\".";
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<string> SaveImageAsync(IFormFile file)
        {
            if (file == null || file.Length == 0) return null;
            var uploads = Path.Combine(_env.WebRootPath, "uploads");
            Directory.CreateDirectory(uploads);
            var ext = Path.GetExtension(file.FileName);
            var name = $"{Guid.NewGuid():N}{ext}";
            var full = Path.Combine(uploads, name);
            using var fs = System.IO.File.Create(full);
            await file.CopyToAsync(fs);
            return $"/uploads/{name}";
        }
    }
}
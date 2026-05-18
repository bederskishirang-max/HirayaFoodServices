using HirayaFoodServices.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HirayaFoodServices.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["Title"] = "Sign In";
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            //ViewData["Title"] = "Sign In";
            //if (!ModelState.IsValid) return View(model);

            //// TODO: replace with real authentication (ASP.NET Identity, custom user store, etc.)
            //// Example placeholder check — remove in production:
            //if (model.Email == "admin@hirayafoods.ph" && model.Password == "admin")
            //{
            //    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
            //        return Redirect(model.ReturnUrl);
            //    return RedirectToAction("Index", "Admin");
            //}

            //ModelState.AddModelError(string.Empty, "Invalid email or password.");
            //return View(model);


            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            // TODO: sign out the user (HttpContext.SignOutAsync, etc.)
            return RedirectToAction("Index", "Home");
        }
    }

}

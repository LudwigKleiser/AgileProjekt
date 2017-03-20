using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BookingWebsite.Models;

namespace BookingWebsite.Controllers
{
    public class UsersController : Controller
    {
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;
        IdentityDbContext identityContext;

        public UsersController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IdentityDbContext identityContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.identityContext = identityContext;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UsersRegisterVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Create the DB Schema
           // await identityContext.Database.EnsureCreatedAsync();

            // 1. Create user
            var user = new IdentityUser(model.Username);
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(
                    nameof(UsersRegisterVM.Username),
                    result.Errors.First().Description);

                return View(model);
            }

            await signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

            // 3. Redirect user
            return RedirectToAction(nameof(CustomersController.EditCustomer));
        }

        public async Task<IActionResult> CreateTables()
        {
       // await identityContext.Database.EnsureCreatedAsync();


            return RedirectToAction(nameof(CustomersController.Index));
    }
    }
}

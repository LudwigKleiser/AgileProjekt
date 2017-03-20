using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BookingWebsite.Models.Entities;
using BookingWebsite.Models;

namespace BookingWebsite.Controllers
{
    public class UsersController : Controller
    {
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;
        IdentityDbContext identityContext;
        RoleManager<IdentityRole> roleManager;
        HotelASPContext context;

        public UsersController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IdentityDbContext identityContext,
            RoleManager<IdentityRole> roleManager,
            HotelASPContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.identityContext = identityContext;
            this.roleManager = roleManager;
            this.context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
            roleManager.CreateAsync(new IdentityRole("Admin"));
            roleManager.CreateAsync(new IdentityRole("Customer"));
            
            
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

           else if (result.Succeeded)
            {
                model.AspnetId = user.Id;
            }
            ActionContext.adduder(model, )
            await signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            

            // 3. Redirect user
            return RedirectToAction(nameof(CustomersController.EditCustomer));
        }

        
    }
}

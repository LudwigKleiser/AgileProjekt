using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BookingWebsite.Models.Entities;
using BookingWebsite.Models;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = "SuperAdmin")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            //await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
            //await roleManager.CreateAsync(new IdentityRole("Admin"));
            //await roleManager.CreateAsync(new IdentityRole("Customer"));
            var user = new IdentityUser("Superadmin");
            var result = await userManager.CreateAsync(user, "Abc123!");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "SuperAdmin");
            }
            
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
                model.AspNetUserId = user.Id;
            }
            
            await signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            

            // 3. Redirect user
            return RedirectToAction(nameof(UsersController.Index));
        }

        
    }
}

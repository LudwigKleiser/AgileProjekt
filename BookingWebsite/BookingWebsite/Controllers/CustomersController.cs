using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookingWebsite.Models.Entities;

namespace BookingWebsite.Controllers
{
    public class CustomersController : Controller
    {

        TempDatabaseContext context;
        

        public CustomersController(TempDatabaseContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
           var models = context.GetCustomersForIndex();
            return View(models);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            context.AddCustomer(customer);
            return RedirectToAction(nameof(CustomersController.Index));

            return View();
        }
    }
}

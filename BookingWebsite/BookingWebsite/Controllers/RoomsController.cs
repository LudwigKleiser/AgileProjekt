using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using BookingWebsite.Models.Entities;
using BookingWebsite.Models;
using Microsoft.Extensions.FileProviders;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingWebsite.Controllers
{
    public class RoomsController : Controller
    {
        private IHostingEnvironment env;
        HotelASPContext context;
        public RoomsController(
            HotelASPContext context,
            IHostingEnvironment env)
        {
            this.context = context;
            this.env = env;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            Room[] model = context.GetRoomsForIndex();
            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Room room = context.GetRoomForDetails(id);
            RoomsDetailsVM model = new RoomsDetailsVM(env)
            {
                Id = room.Id,
                Name = room.Name,
                Number = room.Number,
                Price = room.Price,
                Size = room.Size,
            };
            return View(model);
        }
    }
}

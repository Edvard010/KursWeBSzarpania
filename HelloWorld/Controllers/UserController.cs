using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            var vm = new EditUserViewModel
            {
                FirstName = "Marek",
                LastName = "Zając",
                Age = 28,
                Description = "opis",
                Id = 11
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(EditUserViewModel data)
        {
            return RedirectToAction("Index");
        }

        
    }
}

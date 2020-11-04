using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    public class UserController : Controller
    {
        private IWebHostEnvironment _hostingEnvironment;
        public UserController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
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
                Password = "password",
                Description = "opis",
                Id = 11
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(EditUserViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }

            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            var filePath = Path.Combine(uploads, data.MyFile.FileName);

            data.MyFile.CopyTo(new FileStream(filePath, FileMode.Create));

            return RedirectToAction("Index");
        }

        
    }
}

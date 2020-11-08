using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloWorld.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.IO.Enumeration;

namespace HelloWorld.Controllers
{
    public class RegisterController : Controller
    {
        private IWebHostEnvironment _hostingEnvironment;
        public RegisterController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(RegisterViewModel data)
        {
            if (!data.PasswordConfirmed())
            {
                ModelState.AddModelError("ConfirmPassword", "Hasła nie są takie same");
            }
            if (!ModelState.IsValid)
            {
                return View(data);
            }

            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            var filePath = Path.Combine(uploads, data.Avatar.FileName);

            data.Avatar.CopyTo(new FileStream(filePath, FileMode.Create));

            return RedirectToRoute("test");

        }
    }
}

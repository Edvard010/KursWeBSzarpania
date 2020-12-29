using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloWorld.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.IO.Enumeration;
using HelloWorld.Models.Services;
using Microsoft.AspNetCore.Identity;
using HelloWorld.Models.Entities;

namespace HelloWorld.Controllers
{
    public class RegisterController : Controller
    {
        private UserService _userService;
        private UserManager<CustomUser> _userManager;

        public RegisterController(UserService userService, UserManager<CustomUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        [HttpGet]
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

            var entity = new CustomUser
            {
                UserName = data.Login,
                AboutMe = data.AboutMe,
                FirstName = data.FirstName,
                LastName = data.LastName,
                                
            };

            var result = _userManager.CreateAsync(entity, data.Password).Result;

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(data);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HelloWorld.Models;
using HelloWorld.Models.Services;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller

    {
        private UserService _userService;
        private AboutService _aboutService;
        private ProjectService _projectService;
        public HomeController(AboutService aboutService, UserService userService, ProjectService projectService)
        {
            _aboutService = aboutService;
            _userService = userService;
            _projectService = projectService;
        }

        public IActionResult Index()
        {
            var vm = new UsersListViewModel
            {
                Users = _userService.GetAll()
            };
        
            return View(vm);
        }
        public IActionResult About()
        {

            var vm = _aboutService.Create("Marek", "Zając");
            return View(vm);
        }

        public IActionResult Remove(int id)
        {
            _userService.Remove(id);
            return RedirectToAction("Index");
        }
        public IActionResult Project()
        {
            _projectService.Create();
            return RedirectToAction("Index");
        }
    }    
}

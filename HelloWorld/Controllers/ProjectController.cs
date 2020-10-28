using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details()
        {
            var project = new ProjectViewModel()
            {
                Cena = 1000,
                Nazwa = "Projekt 1"
            };
            return View(project);
        }
    }
}

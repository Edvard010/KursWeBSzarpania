﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HelloWorld.Models;
using HelloWorld.Models.Entities;
using HelloWorld.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    
    public class UserController : Controller
    {
        private UserService _userService;
        private SignInManager<CustomUser> _signInManager;
        private UserManager<CustomUser> _userManager;

        public UserController(UserService userService,
            SignInManager<CustomUser> signInManager,
            UserManager<CustomUser> userManager)
        {
            _userService = userService;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        //[Authorize]
        public IActionResult Edit(int id)
        {
            var userId = _userManager.GetUserId(User);

            var vm = _userService.GetToEdit(id);
            vm.UserId = userId;
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(EditUserViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }

            _userService.Update(data);
            return RedirectToAction("Index", "Home");

        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var vm = _userService.GetToDetails(id);
            return View(vm);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel data)
        {
            var result = _signInManager.PasswordSignInAsync(data.UserName, data.Password, false, false).Result;
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");

            }
            ModelState.AddModelError("", "Nieprawidłowe dane");
            return View();
        }
    }
}

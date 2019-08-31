using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Models;
using PizzaBox.Data;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Controllers
{
    public class UserController
    {
        private ProjectZeroTwoDBContext _db = new ProjectZeroTwoDBContext();

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _db.Users.Single(u => u.UserName == username && u.Password == password);
            return View(user);
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                _db.Users.Add(user);
                _db.SaveChangesAsync();
            }
            return View();
        }

        public ViewResult UserHome(User user)
        {
            return View(user);
        }

    }
}
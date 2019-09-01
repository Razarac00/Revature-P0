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
    public class UserController : Controller
    {
        private ProjectZeroTwoDBContext _db = new ProjectZeroTwoDBContext();


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            try
            {
                var user = _db.Users.Single(u => u.UserName == username && u.Password == password);
                return RedirectToAction("UserHome",user);
            }
            catch (System.Exception)
            {
                
                return RedirectToAction("Error");
            }

        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(User user, Name name)
        {
            var finalUser = user;
            finalUser.Name = name;
            if (ModelState.IsValid)
            {
                _db.Users.Add(finalUser);
                _db.SaveChangesAsync();

                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult UserHome(User user)
        {
            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
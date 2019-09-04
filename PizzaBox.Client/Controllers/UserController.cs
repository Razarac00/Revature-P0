using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                if (user == null)
                {
                    return RedirectToAction("Login");
                }
                return RedirectToAction("UserHome",user);
            }
            catch (System.Exception)
            {
                return RedirectToAction("Login");
                // return RedirectToAction("Error");
            }

        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUser(User user)
        {
            
            if (ModelState.IsValid)
            {
                var finalUser = user;
                // finalUser.Name = name;

                _db.Users.Add(finalUser);
                _db.SaveChangesAsync();

                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult UserHome(User user)
        {
            var loadedUser = _db.Users.Include("Name").Single(u => u.UserId == user.UserId);
            TempData["UserID"] = loadedUser.UserId;
            TempData["UserName"] = loadedUser.UserName;
            TempData.Keep();
            return View(loadedUser);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Locations()
        {
            var storeAddresses = _db.Addresses.ToList();
            var userId = (int) TempData["UserID"];
            TempData["UserID"] = userId;
            TempData.Keep();
            return View(storeAddresses);
        }

        [HttpGet]
        public IActionResult MakeOrder(int addressId)
        {
            var userId = (int) TempData["UserID"];
            var user = _db.Users.Single(u => u.UserId == userId);
            TempData["UserID"] = userId;
            TempData["AddressID"] = addressId;
            TempData.Keep();
            return RedirectToAction("createorder", "order");
        }
        public IActionResult MakeOrder(Address address)
        {
            var loadedUser = _db.Users.Single(u => u.UserId == (int) TempData["UserID"]);
            var chosenAddress = _db.Addresses.Single(a => a.AddressId == address.AddressId);
            loadedUser.StartOrder(chosenAddress);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
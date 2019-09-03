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
    public class OrderController : Controller
    {
        private ProjectZeroTwoDBContext _db = new ProjectZeroTwoDBContext();

        [HttpGet]
        public IActionResult CreateOrder()
        {
            var storeAddresses = _db.Addresses.ToList();
            var toppings = _db.Toppings.ToList();
            var crusts = _db.Crusts.ToList();
            var sizes = _db.Sizes.ToList();
            ViewBag.StoreAddresses = storeAddresses;
            ViewBag.Toppings = toppings;
            ViewBag.Crusts = crusts;
            ViewBag.Sizes = sizes;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateOrder(AddressedOrder addressedOrder, int addressId)
        {
            if (ModelState.IsValid)
            {
                var userId = (int) TempData["UserID"];
                var currentAddress = _db.Addresses.Single(a => a.AddressId == addressId);
                var currentUser = _db.Users.Single(u => u.UserId == userId);
                AddressedOrder finalOrder = new AddressedOrder();
                finalOrder.Address = currentAddress;
                // finalOrder.UserId = userId;
                finalOrder.OrderUser = currentUser;

                _db.AddressedOrders.Add(finalOrder);
                _db.SaveChanges();
            }
            return View();
        }
    }
}
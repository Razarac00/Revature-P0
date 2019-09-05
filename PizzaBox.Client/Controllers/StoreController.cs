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
    public class StoreController : Controller
    {
        private ProjectZeroTwoDBContext _db = new ProjectZeroTwoDBContext();

        [HttpGet]
        public IActionResult Main()
        {
            return View();
        }

        [HttpGet("{StoreId}")]
        public IActionResult ViewOrders(int StoreId)
        {
            var currentStore = _db.Stores.Include(s => s.ViewOrders()).ToList();
            // var storeOrderHistory = ;
            return View(currentStore);
        }

        [HttpGet]
        public ViewResult Read()
        {
            var stores = _db.Stores.Include(s => s.Location).ToList();
            return View(stores);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Store store)
        {
            if (ModelState.IsValid)
            {
                Store finalStore = store;

                _db.Stores.Add(finalStore);
                _db.SaveChanges();

                return RedirectToAction("Read");
            }

            return View();
        }
    }
}
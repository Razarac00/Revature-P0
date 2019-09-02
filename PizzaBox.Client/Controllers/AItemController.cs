using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Client.Models;
using PizzaBox.Data;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Client.Controllers
{
    public class AItemController : Controller
    {
        private ProjectZeroTwoDBContext _db = new ProjectZeroTwoDBContext();

        [HttpGet]
        public ActionResult Read()
        {
            var discriminator = (string) TempData["dis"];
            var result = new List<AItem>();

            if (discriminator == "all")
            {
                result = _db.AItems.ToList();
            }
            else if (discriminator == "toppings")
            {
                result = _db.Toppings.Cast<AItem>().ToList();
            }
            else if (discriminator == "crusts")
            {
                result = _db.Crusts.Cast<AItem>().ToList();
            }
            else if (discriminator == "sizes")
            {
                result = _db.Sizes.Cast<AItem>().ToList();
            }

            return View(result);
        }

        [HttpGet]
        public IActionResult All()
        {
            TempData["dis"] = "all";
            return RedirectToAction("Read");
        } 

        [HttpGet]
        public IActionResult Toppings()
        {
            TempData["dis"] = "toppings";
            return RedirectToAction("Read");
        }

        [HttpGet]
        public IActionResult Crusts()
        {
            TempData["dis"] = "crusts";
            return RedirectToAction("Read");
        } 

        [HttpGet]
        public IActionResult Sizes()
        {
            TempData["dis"] = "sizes";
            return RedirectToAction("Read");
        }  

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string name, decimal price, string discriminator)
        {
        if (ModelState.IsValid)
        {
            if (discriminator == "crust")
            {
                var crust = new Crust(name, price);
                _db.Crusts.Add(crust);
                _db.SaveChanges();
            }
            else if (discriminator == "size")
            {
                var size = new Size(name, price);
                _db.Sizes.Add(size);
                _db.SaveChanges();
            }
            else if (discriminator == "topping")
            {
                var topping = new Topping(name, price);
                _db.Toppings.Add(topping);
                _db.SaveChanges();
            }

            return RedirectToAction("All");
        }
        
        return View();
        }
    }
}
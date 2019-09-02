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
        public ViewResult Read(List<AItem> itemList)
        {
            return View(itemList);
        }

        [HttpGet]
        public IActionResult All()
        {
            var allItems = _db.Toppings.Include("Crust").Include("Size").ToList();
            return RedirectToAction("Read", allItems);
        } 

        [HttpGet]
        public IActionResult Toppings()
        {
            var allToppings = _db.Toppings.ToList();
            return RedirectToAction("Read", allToppings);
        }

        [HttpGet]
        public IActionResult Crusts()
        {
            var allCrusts = _db.Crusts.ToList();
            return RedirectToAction("Read", allCrusts);
        } 

        [HttpGet]
        public IActionResult Sizes()
        {
            var allSizes = _db.Sizes.ToList();
            return RedirectToAction("Read", allSizes);
        }  

        [HttpGet]
        public IActionResult Create()
        {
        return View();
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Crust crust)
        {
        if (ModelState.IsValid)
        {
            _db.Crusts.Add(crust);
            _db.SaveChanges();

            return RedirectToAction("Read");
        }
        
        return View();
        }
    }
}
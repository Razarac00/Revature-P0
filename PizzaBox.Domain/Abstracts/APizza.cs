using System.Collections.Generic;
using EF = PizzaBox.Data.Entities;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    public abstract class APizza : ISellable  // The general pizza idea. The parts of the pizza but not the product
    {
        private static string _defaultCrust = "traditional";
        private static string _defaultSize = "medium";
        private List<Topping> _toppings = new List<Topping>();
        private Crust _crust = new Crust(_defaultCrust);
        private Size _size = new Size(_defaultSize);
        private decimal _price = 0m;
        public List<Topping> Toppings { get => _toppings; set => _toppings = value; }
        public Crust Crust { get => _crust; set => _crust = value; }
        public Size Size { get => _size; set => _size = value; }

        public decimal Price { get => getPrice(); set => _price = value; }

        private void Save()
        {
            var db = new EF.projectzeroDBContext();
            db.Pizza.Add(new Data.Entities.Pizza
            {
                //PizzaName = Name,
                // = Price,
                // CrustId = new EF.Crust
                Active = true
            });
            
            db.SaveChanges();
        }

        private decimal getPrice()
        {
            if (_price > 0m)
            {
                return _price;
            }
            else
            {
                return ComputePrice();
            }
        }
        private decimal ComputePrice()
        {
            decimal total = 0m;
            foreach (var item in Toppings)
            {
                total += item.Price;
            }
            total += Crust.Price;
            total += Size.Price;

            return total;
        }
        public string Name { get; set; }

        protected APizza()
        {
        } 
    }
}
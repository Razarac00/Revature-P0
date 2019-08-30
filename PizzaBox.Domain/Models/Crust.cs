using System;
using System.Collections.Generic;
//using PizzaBox.Data.Entities;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Domain.Models
{
    public class Crust : AItem
    {
        private decimal _defaultPrice = 1.50m;

        public override decimal Price
        {
            get => _defaultPrice;
            set => _defaultPrice = SetupPrice(value);
        }

        // private void Save()
        // {
        //     var db = new projectzeroDBContext();
        //     db.Crust.Add(new Data.Entities.Crust
        //     {
        //         CrustName = Name,
        //         Price = Price,
        //         Active = true
        //     });
            
        //     db.SaveChanges();
        // }

        public Crust(string name) : base(name)
        {
        }

    }
}
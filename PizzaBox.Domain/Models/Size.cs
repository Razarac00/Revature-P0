using System;
using System.Collections.Generic;
// using PizzaBox.Data.Entities;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Size : AItem
    {
        public int SizeId { get; set; }
        // private void Save()
        // {
        //     var db = new projectzeroDBContext();
        //     db.Size.Add(new Data.Entities.Size
        //     {
        //         Size1 = Name,
        //         Price = Price,
        //         Active = true
        //     });
            
        //     db.SaveChanges();
        // }
        public Size(string name, decimal price) : base(name, price) {}
        public Size(string name) : base(name) {}
    }
}
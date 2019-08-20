using System;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Recipes;
using System.Collections.Generic;

namespace PizzaBox.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //MessWithToppings();
        }

        public void MessWithToppings()
        {
            Topping hab = new Topping("habanero");
            System.Console.WriteLine(hab.Price + " " + hab.Name);
        }

        public void MakeNewYork()
        {
            var ny = new NewYork();
            ny.Make(new Size("small"), new List<Topping>());
        } 
    }
}

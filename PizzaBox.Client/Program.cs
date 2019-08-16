using System;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Interfaces;

namespace PizzaBox.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MessWithToppings();
        }

        private static void MessWithToppings()
        {
            Topping hab = new Topping("habanero");
            System.Console.WriteLine(hab.Price);
        }
    }
}

using System;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Recipes;
using System.Collections.Generic;
using PizzaBox.Domain.UIScreens;

namespace PizzaBox.Client
{
    class Program
    {


        static void Main(string[] args)
        {
            Start();
            //MessWithToppings();
        }

        /**
        + as a user i should be able to register
        + as a user i should be able to signin
        + as a user i should be able to view a list of locations
        + as a user i should be able to select a location
        + as a user i should be able to make an order
        + as a user i should be able to choose custom or preset pizza(s)
        + as a user i should be able to select a crust
        + as a user i should be able to select a size
        + as a user i should be able to select a set of toppings
        + as a user i should be able to preview my order
        + as a user i should be able to confirm my order
        + as a user i should be able to view my order history
        + as a user i should be able to signout
        */
        public static void Start()
        {
            IntroScreen.Begin();
        }




        private string CleanString(string arg)
        {
            var result = "";
            if (arg != null)
            {
                result = arg.Trim().ToUpper();
            }
            return result;
        }

        public void MessWithToppings()
        {
            Topping hab = new Topping("habanero");
            System.Console.WriteLine(hab.Price + " " + hab.Name);
        }

        public void MakeNewYork()
        {
            var ny = new NewYork();
            ny.Make();
        } 
    }
}

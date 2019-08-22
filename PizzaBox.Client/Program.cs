using System;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Recipes;
using System.Collections.Generic;

namespace PizzaBox.Client
{
    class Program
    {
        // TUI COMMAND BLOCK
        private static string _register = "CREATE";
        private static string _signIn = "LOGIN";
        private static string _view = "VIEW";
        private static string _locations = "LOCATIONS";
        private static string _history = "HISTORY";
        private static string _select = "SELECT";
        private static string _makeOrder = "ORDER";
        private static string _custom = "CUSTOM";
        // need pizza presets
        private static string _yes = "YES";
        private static string _no = "NO";
        private static string _previewOrder = "CHECKOUT";
        private static string _confirmOrder = "CONFIRM";
        private static string _goBack = "BACK";
        private static string _signOut = "LOGOUT";

        // TUI DIRECTION BLOCK
        private static string _invalidArgument = "The input was incorrect. Please try again.";
        private static string _intro = "It's Pizza Time! Welcome to the Pizza Mausoleum!\n";
        private static string _welcome = $"Do you want to sign in (type {_signIn}) or create a new account (type {_register})?";
        private static string _accountName = "Please type your username: ";
        private static string _accountPassword = "Please type your password: ";
        private static string _confirmPassword = "Retype your password to confirm: ";
        private static string _loginSuccess = "\nYou're all set! There's no time like pizza time!\n";
        private static string _logoutOption = $"To Sign out of your account, type {_signOut}";
        private static string _viewLocations = $"To View Pizza Store Locations, type {_view} {_locations}";
        private static string _selectALocation = $"To pick a store to order from, type {_select} and then the store Address";
        private static string _locationSuccess = "\nLocation set! P I Z Z A T I M E\n";
        private static string _choosePizza = $"Make your own pizza? (type {_custom}) OR Pick a specialty? (type the Specialty name):";
        private static string _chooseCrust = "Pick your crust (type the Crust name):";
        private static string _chooseSize = "What size pizza? (type the Size)";
        private static string _chooseToppings = "Select your toppings! No more than 5! (type the Topping name)";
        private static string _addToCart = $"Continue Shopping? (type {_yes} or {_no})";
        private static string _checkoutCart = $"Preview your Order? (type {_previewOrder})";
        private static string _goBackToCart = $"Type {_goBack} to restart your order.";
        private static string _confirmCartOrder = $"Type {_confirmOrder} to confirm purchase!";
        private static string _viewOrderHistory = $"To view your past orders, type {_view} {_history}";


        static void Main(string[] args)
        {
            Console.WriteLine(_intro);
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
        public void WelcomeScreen()
        {
            Console.WriteLine(_welcome);
            string AccessCall = CleanString(Console.ReadLine());
            if (AccessCall == _signIn)
            {
                SignInScreen();
            }
            else if (AccessCall == _register)
            {
                
            }
            else
            {
                Console.WriteLine(_invalidArgument);
            }
        }

        public void SignInScreen()
        {
            Console.WriteLine("||| Sign In |||");
            Console.WriteLine(_accountName);
            string potentialName = CleanString(Console.ReadLine());
            
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
            ny.Make(new Size("small"), new List<Topping>());
        } 
    }
}

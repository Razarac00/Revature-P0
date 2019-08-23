using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.UIScreens
{
    public class UserHomeScreen : AScreen
    {
        private Store OptionSelect(User potentialUser)
        {
            Console.WriteLine($"\n||| HOME |||\nWelcome {potentialUser.Name.First} {potentialUser.Name.Last}");
            Console.WriteLine(_viewOrderHistory);
            Console.WriteLine(_viewLocations);
            Console.WriteLine(_selectALocation);
            Console.WriteLine(_logoutOption);

            string option = CleanString(Console.ReadLine());
            Store store = null;

            if (option == _signOut)
            {
                Console.WriteLine(_loggingOut);
                IntroScreen intro = new IntroScreen();
                intro.Begin();
            }
            else if (option == $"{_view} {_locations}")
            {
                Console.WriteLine(StoreLocations.Instance());
            }
            else if (option == $"{_view} {_history}")
            {
                Console.WriteLine(potentialUser.UserOrderHistory);
            }
            else if (option.Contains(_select))
            {
                store = GetStoreByAddress(option.Replace(_select, "").Trim());
            }
            else
            {
                Console.WriteLine(_invalidArgument);
            }
            return store;
        }

        private Store GetStoreByAddress(string addressLine)
        {
            foreach (var store in StoreLocations.Instance())
            {
                if (store.Location.AddressLine.ToUpper() == addressLine.ToUpper())
                {
                    return store;
                }
            }
            return null;
        }

        internal void Begin(User potentialUser)
        {
            Store s = null;
            do
            {
                s = OptionSelect(potentialUser);
            } while (s == null);
            Console.WriteLine(_locationSuccess);
        }

    }
}
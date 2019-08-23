using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.UIScreens
{
    public class UserHomeScreen : AScreen
    {
        internal void Begin(User potentialUser)
        {
            Console.WriteLine($"\n||| HOME |||\nWelcome {potentialUser.Name.First} {potentialUser.Name.Last}");
        }
    }
}
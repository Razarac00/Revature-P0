using System;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.UIScreens
{
    public class UserOrderScreen : AScreen
    {
        private Order SelectOrderType(User realUser, Store s)
        {
            PrintColoredText($"\n||| PIZZA SELECTION |||\n");
            Console.WriteLine(_choosePizza);
            Console.WriteLine(_logoutOption);
            string option = CleanString(Console.ReadLine());
            Order order = null;

            if (option == _signOut)
            {
                Console.WriteLine(_loggingOut);
                IntroScreen intro = new IntroScreen();
                intro.Begin();
            }
            else if (option == _custom)
            {
                Console.WriteLine("Coming Soon");
            }
            else
            {
                Console.WriteLine(_invalidArgument);
            }
            return order;
        }
        internal void Begin(User realUser, Store s)
        {
            Order potentialOrder = null;
            do
            {
                SelectOrderType(realUser, s);
            } while (potentialOrder == null);
        }
    }
}
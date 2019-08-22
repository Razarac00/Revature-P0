using System;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.UIScreens
{
    public class IntroScreen : AScreen
    {
        public static void Begin()
        {
            Console.WriteLine(_intro);
        }
    }
}
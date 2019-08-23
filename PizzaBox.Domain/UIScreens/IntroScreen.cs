using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.UIScreens
{
    public class IntroScreen : AScreen
    {
        public void Begin()
        {
            Console.WriteLine(_intro);
            var userEntrance = new LoginSignUpScreen();
            userEntrance.Begin();
        }
    }
}
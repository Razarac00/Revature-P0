using System;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.UIScreens
{
    public class LoginSignUpScreen : AScreen
    {
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
    }
}
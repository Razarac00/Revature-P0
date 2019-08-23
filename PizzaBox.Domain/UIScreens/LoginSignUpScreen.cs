using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.UIScreens
{
    public class LoginSignUpScreen : AScreen
    {
        private User WelcomeScreen()
        {
            User potentialUser = null;

            Console.WriteLine(_welcome);
            string Arg = CleanString(Console.ReadLine());
            if (Arg == _signIn)
            {
                potentialUser = SignInScreen();
            }
            else if (Arg == _register)
            {
                potentialUser = CreateUserScreen();
            }

            return potentialUser;
        }

        private User SignInScreen()
        {
            PrintColoredText("||| Sign In |||");
            Console.WriteLine(_accountName);
            string potentialName = CleanString(Console.ReadLine());
            Console.WriteLine(_accountPassword);
            string potentialPass = Console.ReadLine();

            return UserList.LoginUser(potentialName, potentialPass);    
        }

        private User CreateUserScreen()
        {
            PrintColoredText("||| Create User |||");
            Console.WriteLine(_accountName);
            string potentialName = CleanString(Console.ReadLine());

            Console.WriteLine(_accountPassword);
            string potentialPass = Console.ReadLine();

            Console.WriteLine(_accountFirstName);
            string potentialFirstName = CleanString(Console.ReadLine());

            Console.WriteLine(_accountLastName);
            string potentialLastName = CleanString(Console.ReadLine());

            return UserList.CreateUser(potentialName, potentialFirstName, potentialLastName, potentialPass);
        }

        public void Begin()
        {
            User potentialUser = null;
            do
            {
                potentialUser = WelcomeScreen();
                if (potentialUser == null)
                {
                    Console.WriteLine(_invalidArgument);
                }
            } while (potentialUser == null);
            
            Console.WriteLine(_loginSuccess);
            UserHomeScreen home = new UserHomeScreen();
            home.Begin(potentialUser);
        }
    }
}
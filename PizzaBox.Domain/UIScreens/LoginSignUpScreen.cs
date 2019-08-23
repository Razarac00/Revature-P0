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
            Console.WriteLine("||| Sign In |||");
            Console.WriteLine(_accountName);
            string potentialName = CleanString(Console.ReadLine());
            Console.WriteLine(_accountPassword);
            string potentialPass = Console.ReadLine();

            return LoginUser(potentialName, potentialPass);    
        }

        private User CreateUserScreen()
        {
            Console.WriteLine("||| Create User |||");
            Console.WriteLine(_accountName);
            string potentialName = CleanString(Console.ReadLine());

            Console.WriteLine(_accountPassword);
            string potentialPass = Console.ReadLine();

            Console.WriteLine(_accountFirstName);
            string potentialFirstName = CleanString(Console.ReadLine());

            Console.WriteLine(_accountLastName);
            string potentialLastName = CleanString(Console.ReadLine());

            return CreateUser(potentialName, potentialFirstName, potentialLastName, potentialPass);
        }

        public User CreateUser(string uName, string fName, string lName, string password)
        {
            if (ContainsUserName(uName) == null)
            {
                var user = new User();
                user.UserName = uName;
                user.Name.First = fName;
                user.Name.Last = lName;
                user.Password = password;
                UserList.Instance().Add(user);
                return user;
            }
            return null;
        }

        public User LoginUser(string uName, string password)
        {
            var potentialUser = ContainsUserName(uName);
            if (potentialUser != null && PasswordCheck(potentialUser, password))
            {
                return potentialUser;
            }
            return null;
        }

        private User ContainsUserName(string uName)
        {
            foreach (User u in UserList.Instance())
            {
                if (u.UserName == uName)
                {
                    return u;
                }
            }
            return null;
        }

        private bool PasswordCheck(User u, string password)
        {
            return u.Password == password;
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
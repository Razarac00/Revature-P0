using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Data.Entities;

namespace PizzaBox.Domain.Models
{
    public class UserList
    {
        private static List<User> _users;
        
        public static List<User> Instance()
        {
            projectzeroDBContext db = new projectzeroDBContext();

            if (_users == null)
            {
                _users = new List<User>();
                
            }
            return _users;
        }

        public static User CreateUser(string uName, string fName, string lName, string password)
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

        public static User LoginUser(string uName, string password)
        {
            var potentialUser = ContainsUserName(uName);
            if (potentialUser != null && PasswordCheck(potentialUser, password))
            {
                return potentialUser;
            }
            return null;
        }

        private static User ContainsUserName(string uName)
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

        private static bool PasswordCheck(User u, string password)
        {
            return u.Password == password;
        }

        private UserList() {}
    }
}
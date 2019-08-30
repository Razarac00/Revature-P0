using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
// using PizzaBox.Data.Entities;

namespace PizzaBox.Domain.Models
{
    public class UserList
    {
        private static List<User> _users;
        
        public static List<User> Instance()
        {
            // projectzeroDBContext db = new projectzeroDBContext();

            if (_users == null)
            {
                _users = new List<User>();
                //Read();
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
                //Save(user);
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

        // private static void Read()
        // {
        //     var db = new projectzeroDBContext();
        //     foreach (Data.Entities.User u in db.User)
        //     {
        //         var user = new User();
        //         user.UserName = u.UserName;
        //         user.Name.First = u.FirstName;
        //         user.Name.Last = u.LastName;
        //         user.Password = u.Password;

        //         _users.Add(user);
        //     }
        // }

        // private static void Save(User user)
        // {
        //     var db = new projectzeroDBContext();
        //     db.User.Add(new Data.Entities.User
        //     {
        //         UserName = user.UserName,
        //         FirstName = user.Name.First,
        //         LastName = user.Name.Last,
        //         Password = user.Password
        //     });
        //     db.SaveChanges();
        //     UserList.Instance().Add(user);
        // }

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
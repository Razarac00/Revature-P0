using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public class UserList
    {
        private static List<User> _users;

        public static List<User> Instance()
        {
            if (_users == null)
            {
                _users = new List<User>();
            }
            return _users;
        }

        public static void CreateUser(string uName, string fName, string lName)
        {

        }

        public static void LoginUser(string uName)
        {

        }

        private static bool ContainsUserName(string uName)
        {
            foreach (User u in _users)
            {
                if (u.userName == uName)
                {
                    return true;
                }
            }
            return false;
        }

        private UserList() {}
    }
}
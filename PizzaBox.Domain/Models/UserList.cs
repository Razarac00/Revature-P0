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

        public static bool ContainsUserName(string name)
        {
            foreach (User u in _users)
            {
                if (u.userName == name)
                {
                    return true;
                }
            }
            return false;
        }

        private UserList() {}
    }
}
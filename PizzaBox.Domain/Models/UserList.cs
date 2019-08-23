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

        private UserList() {}
    }
}
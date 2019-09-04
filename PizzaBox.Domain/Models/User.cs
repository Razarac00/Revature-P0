using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Recipes;

namespace PizzaBox.Domain.Models
{
    public class User 
    {
        private Name _name = new Name();
        private int _defaultTimeLimit = 2;
        private int _defaultStoreTImeLimit = 24;
        private static string _recipeNameSpace = "PizzaBox.Domain.Recipes";

        public int UserId { get; set; }
        public Name Name { get => _name; set => _name = value; }

        [Required(ErrorMessage="Username required")]
        public string UserName { get; set; }

        [Required(ErrorMessage="Password required")]
        // [DataType(DataType.Password)]
        public string Password { get; set; }
        public List<AddressedOrder> UserOrderHistory { get; set; }
        private AddressedOrder CurrentOrder { get; set; }
        public Pizza CustomPizza { get; set; }

        public AddressedOrder StartOrder(Address address)
        {
            var order = new Order();
            CurrentOrder = new AddressedOrder(address, order);
            CurrentOrder.OrderUser = this;
            return CurrentOrder;
        }

        public void AddToOrder(string itemType, List<Topping> toppings, Crust crust, Size size)
        {
            Pizza pizza = null;
            if (itemType == "Standard")
            {
                Standard std = new Standard();
                pizza = std.Make() as Pizza;
            }
            else if (itemType == "NewYork")
            {
                NewYork ny = new NewYork();
                pizza = ny.Make() as Pizza;
            }
            
            if (pizza != null)
            {
                pizza.GarnishPizza(toppings, crust, size);
                CurrentOrder.Order.AddToOrderItems(pizza);
            }

        }

        public bool removeFromOrder(Pizza pizza)
        {
            return CurrentOrder.Order.RemoveFromOrderItems(pizza);
        }

        private List<System.Type> getRecipes()
        {
            var query = from classTypes in Assembly.GetExecutingAssembly().GetTypes()
                    where classTypes.IsClass && classTypes.Namespace == _recipeNameSpace
                    select classTypes;
            return query.ToList();
        }

        public AddressedOrder FinishOrder()
        {
            CurrentOrder.Date = DateTime.Now;
            CurrentOrder.FinalPrice = CurrentOrder.Order.ComputeTotalPrice();
            var LatestOrder = getLatestOrder();

            if (LatestOrder is null ||  (CheckTimeLimitReached() && !CheckDailyStoreLimitReached()))
            {
                return CurrentOrder;
            }

            return null;
        }

        private bool CheckTimeLimitReached()
        {
            var result = true;
            var LatestOrder = getLatestOrder();
            if (LatestOrder != null)
            {
                var tempDate = LatestOrder.Date;
                tempDate = tempDate.AddHours(_defaultTimeLimit);

                result = tempDate.CompareTo(CurrentOrder.Date) >= 0;
            }
            
            return result;
        }

        private bool CheckDailyStoreLimitReached()
        {
            var result = false;
            var LatestOrder = getLatestOrder();
            if (LatestOrder != null)
            {
                if (LatestOrder.Address != CurrentOrder.Address)
                {
                    var tempDate = LatestOrder.Date;
                    tempDate = tempDate.AddHours(_defaultStoreTImeLimit);

                    result = tempDate.CompareTo(CurrentOrder.Date) < 0;
                }
            }
            return result;
        }

        public AddressedOrder getLatestOrder()
        {
            return UserOrderHistory.OrderByDescending(o => o.Date).FirstOrDefault();
        }

        public void PrintOrderHistory()
        {
            if (UserOrderHistory == null)
            {
                Console.WriteLine("--- No orders yet! Order some PIZZA! ---");
            }
            else
            {
                foreach (var addressedOrder in UserOrderHistory)
                {
                    Console.WriteLine(addressedOrder.ToString());
                }
            }
        }

    }
}
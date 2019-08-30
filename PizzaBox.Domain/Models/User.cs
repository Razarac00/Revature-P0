using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
// using PizzaBox.Data.Entities;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Recipes;

namespace PizzaBox.Domain.Models
{
    public class User 
    {
        private Name _name = new Name();
        private int _defaultTimeLimit = 2;
        private int _defaultStoreTImeLimit = 24;
        private AddressedOrder _latestOrder = new AddressedOrder();
        private static string _recipeNameSpace = "PizzaBox.Domain.Recipes";
        public int UserId { get; set; }
        // public int AddressedOrderId { get; set; }
        // public int LatestOrderId { get; set; }
        public Name Name { get => _name; set => _name = value; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public OrderHistory UserOrderHistory { get; set; }
        public AddressedOrder LatestOrder { get => _latestOrder; set => _latestOrder = value; }
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
            // var recipeList = getRecipes();
            // foreach (var recipeType in recipeList)
            // {
            //     if (itemType == recipeType.Name)
            //     {
            //         recipeType std = Activator.CreateInstance<recipeType>();
                    
            //     }
            // }
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

            if (LatestOrder is null ||  (CheckTimeLimitReached() && !CheckDailyStoreLimitReached()))
            {
                //Save(CurrentOrder);
                return CurrentOrder;
            }

            return null;
        }

        private bool CheckTimeLimitReached()
        {
            var result = true;
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

        // private void Save(AddressedOrder currentOrder)
        // {
        //     var db = new projectzeroDBContext();
        //     db.UserOrders.Add(new Data.Entities.UserOrders
        //     {
        //         OrderDate = currentOrder.Date,
        //         // AddressId = ,
        //         Active = true
        //     });
        //     LatestOrder = CurrentOrder;
        //     UserOrderHistory.Orders.Add(CurrentOrder);
        //     //db.SaveChanges();
        // }

        public void PrintOrderHistory()
        {
            if (UserOrderHistory == null)
            {
                Console.WriteLine("--- No orders yet! Order some PIZZA! ---");
            }
            else
            {
                foreach (var addressedOrder in UserOrderHistory.Orders)
                {
                    Console.WriteLine(addressedOrder.ToString());
                }
            }
        }

    }
}
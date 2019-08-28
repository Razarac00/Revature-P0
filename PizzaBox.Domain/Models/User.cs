using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PizzaBox.Data.Entities;
using PizzaBox.Domain.Interfaces;
using PizzaBox.Domain.Recipes;

namespace PizzaBox.Domain.Models
{
    public class User 
    {
        private Name _name = new Name();
        private int _defaultTimeLimit = 2;
        private AddressedOrder _latestOrder = new AddressedOrder();
        private static string _recipeNameSpace = "PizzaBox.Domain.Recipes";
        public Name Name { get => _name; set => _name = value; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<AddressedOrder> UserOrderHistory { get; set; }
        public AddressedOrder LatestOrder { get => _latestOrder; set => _latestOrder = value; }
        private AddressedOrder CurrentOrder { get; set; }
        public Pizza CustomPizza { get; set; }

        public AddressedOrder StartOrder(Address address)
        {
            var order = new Order();
            CurrentOrder = new AddressedOrder(address, order);
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

            if (LatestOrder is null ||  CheckTimeLimitReached())
            {
                Save(CurrentOrder);
                return CurrentOrder;
            }

            return null;
        }

        private bool CheckTimeLimitReached()
        {
            var tempDate = LatestOrder.Date;
            tempDate.AddHours(_defaultTimeLimit);

            var result = tempDate.CompareTo(CurrentOrder.Date) >= 0;
            return result;
        }

        private void Save(AddressedOrder currentOrder)
        {
            var db = new projectzeroDBContext();
            db.Order.Add(new Data.Entities.Order
            {
                OrderDate = currentOrder.Date,
                Active = true
            });
            LatestOrder = CurrentOrder;
            UserOrderHistory.Add(CurrentOrder);
            //db.SaveChanges();
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaOrder.placeOrder
{
    public class Pizza
    {
        public string PizzaName { get; set; }
        public double Price { get; set; }
        public List<Ingredient> AddedIngredients {  get; set; }
        public Pizza() { }
        public Pizza(string pizzaName, double price)
        {
            PizzaName = pizzaName;
            Price = price;
            AddedIngredients = new List<Ingredient>();
        }

    }
}
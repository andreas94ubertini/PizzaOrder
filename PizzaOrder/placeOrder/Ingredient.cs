using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaOrder
{
    public class Ingredient
    {
        public double price { get; set; }
        public string IngredientName { get; set; }
        public Ingredient() { }
        public Ingredient(double price, string ingredientName)
        {
            this.price = price;
            IngredientName = ingredientName;
        }
    }
}
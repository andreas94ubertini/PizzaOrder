using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PizzaOrder.placeOrder
{
    public partial class Default : System.Web.UI.Page
    {
        public static List<Pizza> Pizzas = new List<Pizza>();
        public static List<Ingredient> Ingredients = new List<Ingredient>(); 
        public static List<Pizza> CurrentOrder = new List<Pizza>();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            title.InnerText = $"Ciao {User.Identity.Name}, Seleziona una pizza";
            if (!IsPostBack)
            {
                Pizza[] pizzas = {
                new Pizza("Margherita", 6.50),
                new Pizza("Napoli", 5.00),
                new Pizza("Capricciosa", 8.60),
                new Pizza("4 Formaggi", 6.50),
                new Pizza("Marinara", 5.50),
                new Pizza("Boscaiola", 8.00) };
                Pizzas.AddRange(pizzas);
                Ingredient[] ingredients =
                {
                    new Ingredient(2.50, "Mozz. Bufala"),
                    new Ingredient(2.50, "Funghi"),
                    new Ingredient(2.50, "Salame Piccante"),
                    new Ingredient(2.50, "Olive")
                };
                Ingredients.AddRange(ingredients);
                box1.Visible = false;
                box2.Visible = false;

            }
        }

        protected void AddToOrder(int PizzaIndex)
        {
            Pizza pizza = new Pizza(Pizzas[PizzaIndex].PizzaName, Pizzas[PizzaIndex].Price);
            for (int i = 0; i < IngredientBoxList.Items.Count; i++)
            {
                if (IngredientBoxList.Items[i].Selected)
                {
                    int index = Convert.ToInt32(IngredientBoxList.Items[i].Value);
                    pizza.AddedIngredients.Add(Ingredients[index]);
                }
            }
            CurrentOrder.Add(pizza);
        }
        protected void WriteOrder()
        {
            current.InnerHtml = "";
            int index = 0;
            foreach(Pizza p in CurrentOrder)
            {
                index++;
                string toWrite = $"-{index}: {p.PizzaName}";
                if (p.AddedIngredients.Count > 0)
                {
                    foreach (Ingredient i in p.AddedIngredients)
                    {
                        toWrite += $",{i.IngredientName}";
                    }
                }
                toWrite += "</br>";
                current.InnerHtml += toWrite;

            }
        }
       protected void WriteResume()
        {
            total.InnerHtml = "";
            int index = 0;
            double totalTopay = 0;
            foreach (Pizza p in CurrentOrder)
            {
                index++;
                double totAdded = 0;
                string toWrite = $"-{index}: {p.PizzaName}, {p.Price}Eur";
                if (p.AddedIngredients.Count > 0)
                {
                    foreach (Ingredient i in p.AddedIngredients)
                    {
                        toWrite += $",{i.IngredientName}(+ {i.price})";
                        totAdded += i.price;
                    }
                    totalTopay += totAdded;
                    toWrite += $": {p.Price + totAdded}Eur";
                }
                totalTopay += p.Price;
                toWrite += "</br>";
                total.InnerHtml += toWrite;

            }
            finalPrice.InnerHtml =$"Totale da pagare: {totalTopay}Eur </br>";
        }
        protected void ResetForm()
        {
            PizzaSelectionList.SelectedIndex = 0;
            for (int i = 0; i < IngredientBoxList.Items.Count; i++)
            {
                if (IngredientBoxList.Items[i].Selected)
                {
                    IngredientBoxList.Items[i].Selected = false;
                    
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            AddToOrder(Convert.ToInt32(PizzaSelectionList.SelectedItem.Value));
            ResetForm();
            WriteOrder();
            box1.Visible = true;
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            box1.Visible=false;
            box2.Visible=true;
            ResetForm();
            WriteResume();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect(FormsAuthentication.LoginUrl);
        }
    }
}
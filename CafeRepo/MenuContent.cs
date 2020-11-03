using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepo
{
    public class MenuContent
    {
        public double MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Ingredients { get; set; }

        public MenuContent() { }


        public MenuContent(string mealName, string description, int price, double mealNumber, string ingredients)
        {
            MealName = mealName;
            Description = description;
            Price = price;
            MealNumber = mealNumber;
            Ingredients = ingredients;

        }
    }
}

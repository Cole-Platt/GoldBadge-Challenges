using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepo
{
    public class Menu_Item : MenuContent
    {
        public List<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
        public int MenuItemsCount
        {
            get
            {
                return MenuItems.Count;
            }
        }



    }

    public class MenuItem : MenuContent
    {
        private string _title;
        public string MealNameItem
        {
            get
            {
                return _title;
            }
            set
            {
                if (value[0].ToString().ToLower() == value[0].ToString())
                {
                    string capitalizedMeal = "";
                    capitalizedMeal += value[0].ToString().ToUpper();
                    capitalizedMeal += value.Substring(1);
                    _title = capitalizedMeal;
                }
                else
                {
                    _title = value;
                }
            }
        }
        public string DescriptionItem { get; set; }
        public int MealNumberItem { get; set; }
        public int MealPriceItem { get; set; }
        public string MealIngredientsItem { get; set; }


        public MenuItem() { }

        public MenuItem(string mealNameItem, string descriptionItem, int mealNumberItem, int mealPriceItem, string mealIngredientsItem)
        {
            MealNameItem = mealNameItem;
            DescriptionItem = descriptionItem;
            MealNumberItem = mealNumberItem;
            MealPriceItem = mealPriceItem;
            MealIngredientsItem = mealIngredientsItem;
        }
    }
}

using CafeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_Challenges
{
    public class CafeUI
    {
        /*Komodo cafe is getting a new menu. The manager wants to be able to create new menu items, (eventually) update menu items, delete menu items, and receive a list of all items on the cafe's menu. She needs a console app.

 

The Menu Items:
A meal number, so customers can say "I'll have the #5"
A meal name
A description
A list of ingredients,
A price
 

Your Task:
Create a Menu Class with properties, constructors, and fields.
Create a MenuRepository Class that has methods needed.
Create a Test Class for your repository methods. (You don't need to test your constructors or objects, just your methods)
Create a Program file that allows the cafe manager to add, delete, and see all items in the menu list.
 */
        private MenuRepository _repo = new MenuRepository();

        public void Run()
        {
            SeedContent();
            UserMenu();
        }

        private void SeedContent()
        {
            MenuItem cheeseBurger = new MenuItem(
                "Cheese Burger",
                "A simple classic",
                1,
                5,
                "Beef, Cheese, Bread"
                
            ); MenuItem blt = new MenuItem(
                "Bacon Lettuce Tomato",
                "God's gift.",
                2,
                6,
                "Bacon, Lettuce, Bread, Tomato"

            ); MenuItem milkShake = new MenuItem(
                "Milk Shake",
                "Delicious",
                7,
                2,
                "Lots of things you cant read outloud correctly."

            );


            _repo.AddContentToDirectory(milkShake);
            _repo.AddContentToDirectory(cheeseBurger);
            _repo.AddContentToDirectory(blt);
        }

        private void UserMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Enter the number of the option you'd like to select:\n" +
                    "1. Show all menu content\n" +
                    "2. Find menu content by title\n" +
                    "3. Add new menu content\n" +
                    "4. Remove menu item\n" +
                    "5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        // Show all content
                        ShowAllContent();
                        break;
                    case "2":
                        //Get content by title
                        ShowContentByTitle();
                        break;
                    case "3":
                        //Create new streaming content
                        CreateNewContent();
                        break;
                    //case "4":
                        //Update existing content
                        //break;
                    case "4":
                        // Delete existing content
                        DeleteContentByTitle();
                        break;
                    case "5":
                        //Exit
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowAllContent()
        {
            Console.Clear();

            List<MenuContent> listOfContent = _repo.GetContents();

            foreach (MenuContent content in listOfContent)
            {
                DisplayContent(content);
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void CreateNewContent()
        {
            Console.Clear();

            MenuContent newContent = new MenuContent();

            Console.WriteLine("Please enter the new item's name.");
            newContent.MealName = Console.ReadLine();

            Console.WriteLine("Please enter a description.");
            newContent.Description = Console.ReadLine();

            Console.WriteLine("Please enter a Meal Number (1 - 20) for this content.");
            string mealNumberAsString = Console.ReadLine();
            double mealNumberAsDouble = double.Parse(mealNumberAsString);
            newContent.MealNumber = mealNumberAsDouble;
           

            Console.WriteLine("Please enter a price for the new menu item.");
            string priceInput = Console.ReadLine();
            int priceAsInt = int.Parse(priceInput);
            newContent.Price = priceAsInt;


            Console.WriteLine("Please enter the list of ingredients seperated by commas.");
            newContent.Ingredients = Console.ReadLine();



            bool wasAdded = _repo.AddContentToDirectory(newContent);
            if (wasAdded == true)
            {
                Console.WriteLine("Your content was succesfully added.");
            }
            else
            {
                Console.WriteLine("Oops something went wrong. Your content was not added.");
            }
        }

        private void ShowContentByTitle()
        {
            Console.Clear();

            Console.WriteLine("Enter the title of the content you'd like to see.");
            string title = Console.ReadLine();

            MenuContent content = _repo.GetContentByTitle(title);

            if (content != null)
            {
                DisplayContent(content);
            }
            else
            {
                Console.WriteLine("That title doesn't exist.");
            }
            Console.ReadKey();
        }


        private void DeleteContentByTitle()
        {
            ShowAllContent();
            Console.WriteLine("Enter the menu name for the content you would like to delete.");
            string titleToDelete = Console.ReadLine();

            MenuContent contentToDelete = _repo.GetContentByTitle(titleToDelete);
            bool wasDeleted = _repo.DeleteExistingContent(contentToDelete);

            if (wasDeleted)
            {
                Console.WriteLine("This content was successfully deleted.");
            }
            else
            {
                Console.WriteLine("Content could not be deleted");
            }
        }
        //Method that prompts user for which StreamingContent object they want to delete (use the title to find it)
        //remove it from the _contentDirectory.

        

        private void DisplayContent(MenuContent content)
        {
            Console.WriteLine($"Meal name: {content.MealName}");
            Console.WriteLine($"Description: {content.Description}");
            Console.WriteLine($"Meal number: {content.MealNumber}");
            Console.WriteLine($"Price: {content.Price}");
            Console.WriteLine($"Ingredients: {content.Ingredients}");
            
        }
    }
}


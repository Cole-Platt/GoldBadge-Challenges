using GreenPlanRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_GreenPlanConsole
{
    class GreenUI
    {
        /*Komodo Insurance is trying to add a Green Plan for their customers that provides incentives for owning an Electric or Hybrid car. Before they are able to configure any pricing or deals, they want to collect general information on Electric, Hybrid, and Gas cars so that they can do various comparisons.

The purpose of the app on this sprint will be to:
collect, read, delete, and update data on gas, electric, and hybrid cars.

To be more specific, they want to create an app that allows a Komodo Agent to do full CRUD + List on those three types of cars.

For example:
a KI employee can go on and create a Tesla, add it to an Electric Car list, update it, see the details for the car, and delete it from the Electric Car list.

 

They could also see a full list of Electric cars that have been added. They can do the same thing for Gas Cars and Hybrid Cars with the eventual hope that the collected data will help with various comparisons.

 

Be sure to Unit Test your code.*/

        private GreenRepo _repo = new GreenRepo();
        private GreenRepo _gasRepo = new GreenRepo();
        private GreenRepo _electricRepo = new GreenRepo();
        private GreenRepo _hybridRepo = new GreenRepo();

        //

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Enter the number of the option you'd like to select:\n" +
                    "1. Show all lists of car types\n" +
                    "2. Find cars by name\n" +
                    "3. Add new a new car\n" +
                    "4. Update existing cars\n" +
                    "5. Remove a car\n" +
                    "6. Exit");

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
                    case "4":
                        //Update existing content
                        UpdateExistingContent();
                        break;
                    case "5":
                        // Delete existing content
                        DeleteContentByTitle();
                        break;
                    case "6":
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

            List<GreenContent> listOfContent = _repo.GetContents();
            List<GreenContent> listOfContentGas = _gasRepo.GetContents();
            List<GreenContent> listOfContentElectric = _electricRepo.GetContents();
            List<GreenContent> listOfContentHybrid = _hybridRepo.GetContents();


            foreach (GreenContent content in listOfContent)
            {
                DisplayContent(content);
                Console.WriteLine("----------------------------------------");
            }
            Console.WriteLine("This is all content.");
            foreach (GreenContent content in listOfContentGas)
            {
                DisplayContent(content);
                Console.WriteLine("----------------------------------------");

            }
            Console.WriteLine("This is all content in Gas cars.");
            foreach (GreenContent content in listOfContentElectric)
            {
                DisplayContent(content);
                Console.WriteLine("----------------------------------------");

            }
            Console.WriteLine("This is all content in Electric cars.");
            foreach (GreenContent content in listOfContentHybrid)
            {
                DisplayContent(content);
                Console.WriteLine("----------------------------------------");

            }
            Console.WriteLine("This is all content in Hybrid cars.");

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void CreateNewContent()
        {
            Console.Clear();

            GreenContent newContent = new GreenContent();

            Console.WriteLine("Please enter the name of the new car.");
            newContent.CarName = Console.ReadLine();

            Console.WriteLine("Please enter a price for this car.");
            string carPriceAsString = Console.ReadLine();
            int carPriceAsInt = int.Parse(carPriceAsString);
            newContent.CarPrice = carPriceAsInt;

            Console.WriteLine("Please enter a mileage to a refill of either type gas or electric.");
            string mileageToRefillAsString = Console.ReadLine();
            int mileageToRefillAsInt = int.Parse(mileageToRefillAsString);
            newContent.MileageToRefill = mileageToRefillAsInt;

            Console.WriteLine("Please enter a year made for this car.");
            string yearMadeAsString = Console.ReadLine();
            int yearMadeAsInt = int.Parse(yearMadeAsString);
            newContent.YearMade = yearMadeAsInt;






            Console.WriteLine("Select car type.");
            Console.WriteLine("1. Gas");
            Console.WriteLine("2. Electric");
            Console.WriteLine("3. Hybrid");
            string carTypeInput = Console.ReadLine();





            if (carTypeInput == "1")
            {
                newContent.CarType = CarType.Gas;
                bool wasAdded = _gasRepo.AddContentToDirectory(newContent);
                if (wasAdded == true)
                {
                    Console.WriteLine("Your content was succesfully added.");
                }
                else
                {
                    Console.WriteLine("Oops something went wrong. Your content was not added.");
                }
            }
            else if (carTypeInput == "2")
            {
                newContent.CarType = CarType.Electric;
                bool wasAdded = _electricRepo.AddContentToDirectory(newContent);
                if (wasAdded == true)
                {
                    Console.WriteLine("Your content was succesfully added.");
                }
                else
                {
                    Console.WriteLine("Oops something went wrong. Your content was not added.");
                }
            }
            else if (carTypeInput == "3")
            {
                newContent.CarType = CarType.Hybrid;
                bool wasAdded = _hybridRepo.AddContentToDirectory(newContent);
                if (wasAdded == true)
                {
                    Console.WriteLine("Your content was succesfully added.");
                }
                else
                {
                    Console.WriteLine("Oops something went wrong. Your content was not added.");
                }
            }

            bool wasAddedRepo = _repo.AddContentToDirectory(newContent);

            if (wasAddedRepo == true)
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

            GreenContent content = _repo.GetContentByTitle(title);

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

        private void UpdateExistingContent()
        {
            ShowAllContent();
            DeleteContentByTitle();
            CreateNewContent();
        }

        private void DeleteContentByTitle()
        {
            ShowAllContent();
            Console.ReadKey();
            Console.WriteLine("Enter the car's name for the car you would like to delete.");
            string titleToDelete = Console.ReadLine();

            GreenContent contentToDelete = _repo.GetContentByTitle(titleToDelete);
            GreenContent contentToDeleteGas = _gasRepo.GetContentByTitle(titleToDelete);
            GreenContent contentToDeleteElectric = _electricRepo.GetContentByTitle(titleToDelete);
            GreenContent contentToDeleteHybrid = _hybridRepo.GetContentByTitle(titleToDelete);


            bool wasDeleted = _repo.DeleteExistingContent(contentToDelete);
            bool wasDeletedGas = _gasRepo.DeleteExistingContent(contentToDelete);
            bool wasDeletedElectric = _electricRepo.DeleteExistingContent(contentToDelete);
            bool wasDeletedHybrid = _hybridRepo.DeleteExistingContent(contentToDelete);


            if (wasDeleted)
            {
                Console.WriteLine("This content was successfully deleted.");
            }
            else
            {
                Console.WriteLine("Content could not be deleted");
            }

            if (wasDeletedGas)
            {
                Console.WriteLine("This content was successfully deleted.");
            }
            else
            {
                Console.WriteLine("Content could not be deleted");
            }

            if (wasDeletedElectric)
            {
                Console.WriteLine("This content was successfully deleted.");
            }
            else
            {
                Console.WriteLine("Content could not be deleted");
            }

            if (wasDeletedHybrid)
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

        //Bonus: Display all the options for them to select from 

        //work until 2:15

        private void DisplayContent(GreenContent content)
        {
            Console.WriteLine($"Car Name: {content.CarName}");
            Console.WriteLine($"Mileage to Refill: {content.MileageToRefill}");
            Console.WriteLine($"Year Made: {content.YearMade}");
            Console.WriteLine($"Car Price: {content.CarPrice}");
            Console.WriteLine($"Car Type: {content.CarType}");

        }
    }
}


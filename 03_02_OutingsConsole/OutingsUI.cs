using _07_OutingsRepo;
using _07_OutingsRepo.Ievents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_02_OutingsConsole
{
    public class OutingsUI
    {
        /*Komodo accountants need a list of all outings, the cost of all outings combined, and the cost of all types of outings combined.

Here are the parts of an outing:
Event Type:   Golf, Bowling, Amusement Park, Concert
Number of people that attended
Date
Total cost per person for the event
Total cost for the event


Here's what they'd like:
Display a list of all outings.
Add individual outings to a list(don't need to worry about delete yet)
Calculations:
They'd like to see a display for the combined cost for all outings.
They'd like to see a display of outing costs by type.
For example, all bowling outings for the year were $2000.00. All Concert outings cost $5000.00.*/

        private Bowling _bowlingRepo = new Bowling();
        private Concerts _concertsRepo = new Concerts();
        private Golf _golfRepo = new Golf();
        private AmusementParks _amusementRepo = new AmusementParks();



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
                    "1. Show all types of events\n" +
                    "2. Find event details by name\n" +
                    "3. Add new a new instance of an event\n" +
                    "4. Update existing events\n" +
                    "5. Remove an event\n" +
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





            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Enter the number of the option you'd like to select:\n" +
                    "1. Show Bowling Events\n" +
                    "2. Show Concert Events\n" +
                    "3. Show Golf Events\n" +
                    "4. Show Amusement Park Events\n" +
                    "5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":

                        Console.Clear();

                        List<Bowling> listOfContentBowling = _bowlingRepo.GetContents();
                        foreach (Bowling content in listOfContentBowling)
                        {
                            DisplayContent(content);
                            Console.WriteLine("----------------------------------------");
                        }
                        Console.WriteLine("This is all bowling events.");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        List<Concerts> listOfContentConcerts = _concertsRepo.GetContents();
                        foreach (Concerts content in listOfContentConcerts)
                        {
                            DisplayContent(content);
                            Console.WriteLine("----------------------------------------");

                        }
                        Console.WriteLine("This is all concert events.");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        List<Golf> listOfContentGolf = _golfRepo.GetContents();
                        foreach (Golf content in listOfContentGolf)
                        {
                            DisplayContent(content);
                            Console.WriteLine("----------------------------------------");

                        }
                        Console.WriteLine("This is all golf events.");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        List<AmusementParks> listOfContentAmusement = _amusementRepo.GetContents();
                        foreach (AmusementParks content in listOfContentAmusement)
                        {
                            DisplayContent(content);
                            Console.WriteLine("----------------------------------------");

                        }
                        Console.WriteLine("This is all amusement park events.");

                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case "5":

                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void CreateNewContent()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Enter the number of the option you'd like to select:\n" +
                    "1. Create new Bowling Event\n" +
                    "2. Create new Concert Event\n" +
                    "3. Create new Golf Event\n" +
                    "4. Create new Amusement Park Event\n" +
                    "5. Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":

                        Console.Clear();

                        Bowling newContentBowling = new Bowling();

                        Console.WriteLine("Please enter a name for this event.");
                        string nameBowlingAsString = Console.ReadLine();
                        newContentBowling.NameOfEvent = nameBowlingAsString;

                        Console.WriteLine("Please enter the number of people attending the event.");
                        string numberOfPeopleAsString = Console.ReadLine();
                        int numberOfPeopleAsInt = int.Parse(numberOfPeopleAsString);
                        newContentBowling.NumberOfPeople = numberOfPeopleAsInt;

                        Console.WriteLine("Please enter a cost per person for this event.");
                        string costPerPersonAsString = Console.ReadLine();
                        double costPerPersonAsInt = double.Parse(costPerPersonAsString);
                        newContentBowling.CostPerPerson = costPerPersonAsInt;

                        Console.WriteLine("Please enter a total cost for the entire event.");
                        string costOfEntireEventAsString = Console.ReadLine();
                        double costOfEntireEventAsDouble = int.Parse(costOfEntireEventAsString);
                        newContentBowling.CostOfEntireEvent = costOfEntireEventAsDouble;

                        Console.WriteLine("Please enter a date for this event.");
                        string dateAsString = Console.ReadLine();
                        DateTime dateAsDate = DateTime.Parse(dateAsString);
                        newContentBowling.Date = dateAsDate;

                        bool wasAddedRepo = _bowlingRepo.AddContentToDirectory(newContentBowling);

                        if (wasAddedRepo == true)
                        {
                            Console.WriteLine("Your content was succesfully added.");
                        }
                        else
                        {
                            Console.WriteLine("Oops something went wrong. Your content was not added.");
                        }

                        break;
                    case "2":
                        Console.Clear();

                        Concerts newContentConcerts = new Concerts();

                        Console.WriteLine("Please enter a name for this event.");
                        string nameConcertAsString = Console.ReadLine();
                        newContentConcerts.NameOfEvent = nameConcertAsString;

                        Console.WriteLine("Please enter the number of people attending the event.");
                        string numberOfPeopleConcertsAsString = Console.ReadLine();
                        int numberOfPeopleConcertsAsInt = int.Parse(numberOfPeopleConcertsAsString);
                        newContentConcerts.NumberOfPeople = numberOfPeopleConcertsAsInt;

                        Console.WriteLine("Please enter a cost per person for this event.");
                        string costPerPersonConcertsAsString = Console.ReadLine();
                        double costPerPersonConcertsAsInt = double.Parse(costPerPersonConcertsAsString);
                        newContentConcerts.CostPerPerson = costPerPersonConcertsAsInt;

                        Console.WriteLine("Please enter a total cost for the entire event.");
                        string costOfEntireEventConcertsAsString = Console.ReadLine();
                        double costOfEntireEventConcertsAsDouble = int.Parse(costOfEntireEventConcertsAsString);
                        newContentConcerts.CostOfEntireEvent = costOfEntireEventConcertsAsDouble;

                        Console.WriteLine("Please enter a date for this event.");
                        string dateConcertsAsString = Console.ReadLine();
                        DateTime dateConcertsAsDate = DateTime.Parse(dateConcertsAsString);
                        newContentConcerts.Date = dateConcertsAsDate;

                        bool wasAddedRepoConcerts = _concertsRepo.AddContentToDirectory(newContentConcerts);

                        if (wasAddedRepoConcerts == true)
                        {
                            Console.WriteLine("Your content was succesfully added.");
                        }
                        else
                        {
                            Console.WriteLine("Oops something went wrong. Your content was not added.");
                        }
                        break;
                    case "3":

                        Console.Clear();

                        Golf newContentGolf = new Golf();

                        Console.WriteLine("Please enter a name for this event.");
                        string nameGolfAsString = Console.ReadLine();
                        newContentGolf.NameOfEvent = nameGolfAsString;

                        Console.WriteLine("Please enter the number of people attending the event.");
                        string numberOfPeopleGolfAsString = Console.ReadLine();
                        int numberOfPeopleGolfAsInt = int.Parse(numberOfPeopleGolfAsString);
                        newContentGolf.NumberOfPeople = numberOfPeopleGolfAsInt;

                        Console.WriteLine("Please enter a cost per person for this event.");
                        string costPerPersonGolfAsString = Console.ReadLine();
                        double costPerPersonGolfAsInt = double.Parse(costPerPersonGolfAsString);
                        newContentGolf.CostPerPerson = costPerPersonGolfAsInt;

                        Console.WriteLine("Please enter a total cost for the entire event.");
                        string costOfEntireEventGolfAsString = Console.ReadLine();
                        double costOfEntireEventGolfAsDouble = int.Parse(costOfEntireEventGolfAsString);
                        newContentGolf.CostOfEntireEvent = costOfEntireEventGolfAsDouble;

                        Console.WriteLine("Please enter a date for this event.");
                        string dateGolfAsString = Console.ReadLine();
                        DateTime dateGolfAsDate = DateTime.Parse(dateGolfAsString);
                        newContentGolf.Date = dateGolfAsDate;

                        bool wasAddedRepoGolf = _golfRepo.AddContentToDirectory(newContentGolf);

                        if (wasAddedRepoGolf == true)
                        {
                            Console.WriteLine("Your content was succesfully added.");
                        }
                        else
                        {
                            Console.WriteLine("Oops something went wrong. Your content was not added.");
                        }

                        break;
                    case "4":

                        Console.Clear();

                        AmusementParks newContentAmusement = new AmusementParks();

                        Console.WriteLine("Please enter a name for this event.");
                        string nameAmusementAsString = Console.ReadLine();
                        newContentAmusement.NameOfEvent = nameAmusementAsString;

                        Console.WriteLine("Please enter the number of people attending the event.");
                        string numberOfPeopleAmusementAsString = Console.ReadLine();
                        int numberOfPeopleAmusementAsInt = int.Parse(numberOfPeopleAmusementAsString);
                        newContentAmusement.NumberOfPeople = numberOfPeopleAmusementAsInt;

                        Console.WriteLine("Please enter a cost per person for this event.");
                        string costPerPersonAmusementAsString = Console.ReadLine();
                        double costPerPersonAmusementAsInt = double.Parse(costPerPersonAmusementAsString);
                        newContentAmusement.CostPerPerson = costPerPersonAmusementAsInt;

                        Console.WriteLine("Please enter a total cost for the entire event.");
                        string costOfEntireEventAmusementAsString = Console.ReadLine();
                        double costOfEntireEventAmusementAsDouble = int.Parse(costOfEntireEventAmusementAsString);
                        newContentAmusement.CostOfEntireEvent = costOfEntireEventAmusementAsDouble;

                        Console.WriteLine("Please enter a date for this event.");
                        string dateAmusementAsString = Console.ReadLine();
                        DateTime dateAmusementAsDate = DateTime.Parse(dateAmusementAsString);
                        newContentAmusement.Date = dateAmusementAsDate;

                        bool wasAddedRepoAmusement = _amusementRepo.AddContentToDirectory(newContentAmusement);

                        if (wasAddedRepoAmusement == true)
                        {
                            Console.WriteLine("Your content was succesfully added.");
                        }
                        else
                        {
                            Console.WriteLine("Oops something went wrong. Your content was not added.");
                        }

                        break;
                    case "5":

                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void ShowContentByTitle()
        {



            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Enter the number of the option you'd like to select:\n" +
                    "1. Find Bowling Events by name\n" +
                    "2. Find Concert Events by name\n" +
                    "3. Find Golf Events by name\n" +
                    "4. Find Amusement Park Events by name\n" +
                    "5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":

                        Console.Clear();

                        Console.WriteLine("Enter the title of the content you'd like to see.");
                        string titleBowling = Console.ReadLine();

                        Bowling contentBowling = _bowlingRepo.GetContentByTitle(titleBowling);

                        if (contentBowling != null)
                        {
                            DisplayContent(contentBowling);
                        }
                        else
                        {
                            Console.WriteLine("That title doesn't exist.");
                        }
                        Console.ReadKey();

                        break;
                    case "2":

                        Console.Clear();

                        Console.WriteLine("Enter the title of the content you'd like to see.");
                        string titleConcerts = Console.ReadLine();

                        Concerts contentConcerts = _concertsRepo.GetContentByTitle(titleConcerts);

                        if (contentConcerts != null)
                        {
                            DisplayContent(contentConcerts);
                        }
                        else
                        {
                            Console.WriteLine("That title doesn't exist.");
                        }
                        Console.ReadKey();

                        break;
                    case "3":

                        Console.Clear();

                        Console.WriteLine("Enter the title of the content you'd like to see.");
                        string titleGolf = Console.ReadLine();

                        Golf contentGolf = _golfRepo.GetContentByTitle(titleGolf);

                        if (contentGolf != null)
                        {
                            DisplayContent(contentGolf);
                        }
                        else
                        {
                            Console.WriteLine("That title doesn't exist.");
                        }
                        Console.ReadKey();

                        break;
                    case "4":

                        Console.Clear();

                        Console.WriteLine("Enter the title of the content you'd like to see.");
                        string titleAmusement = Console.ReadLine();

                        AmusementParks contentAmusement = _amusementRepo.GetContentByTitle(titleAmusement);

                        if (contentAmusement != null)
                        {
                            DisplayContent(contentAmusement);
                        }
                        else
                        {
                            Console.WriteLine("That title doesn't exist.");
                        }
                        Console.ReadKey();

                        break;
                    case "5":

                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option");
                        Console.ReadKey();
                        break;
                }
            }
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



            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Enter the number of the option you'd like to select:\n" +
                    "1. Find Bowling Events by name\n" +
                    "2. Find Concert Events by name\n" +
                    "3. Find Golf Events by name\n" +
                    "4. Find Amusement Park Events by name\n" +
                    "5. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":

                        Console.ReadKey();
                        Console.WriteLine("Enter the car's name for the car you would like to delete.");
                        string titleToDeleteBowling = Console.ReadLine();
                        Bowling contentToDeleteBowling = _bowlingRepo.GetContentByTitle(titleToDeleteBowling);
                        bool wasDeletedBowling = _bowlingRepo.DeleteExistingContent(contentToDeleteBowling);
                        if (wasDeletedBowling)
                        {
                            Console.WriteLine("This content was successfully deleted.");
                        }
                        else
                        {
                            Console.WriteLine("Content could not be deleted");
                        }

                        break;
                    case "2":

                        Console.ReadKey();
                        Console.WriteLine("Enter the car's name for the car you would like to delete.");
                        string titleToDeleteConcerts = Console.ReadLine();
                        Concerts contentToDeleteConcert = _concertsRepo.GetContentByTitle(titleToDeleteConcerts);
                        bool wasDeletedConcert = _concertsRepo.DeleteExistingContent(contentToDeleteConcert);
                        if (wasDeletedConcert)
                        {
                            Console.WriteLine("This content was successfully deleted.");
                        }
                        else
                        {
                            Console.WriteLine("Content could not be deleted");
                        }

                        break;
                    case "3":

                        Console.ReadKey();
                        Console.WriteLine("Enter the car's name for the car you would like to delete.");
                        string titleToDeleteGolf = Console.ReadLine();
                        Golf contentToDeleteGolf = _golfRepo.GetContentByTitle(titleToDeleteGolf);
                        bool wasDeletedGolf = _golfRepo.DeleteExistingContent(contentToDeleteGolf);
                        if (wasDeletedGolf)
                        {
                            Console.WriteLine("This content was successfully deleted.");
                        }
                        else
                        {
                            Console.WriteLine("Content could not be deleted");
                        }


                        break;
                    case "4":

                        Console.ReadKey();
                        Console.WriteLine("Enter the car's name for the car you would like to delete.");
                        string titleToDeleteAmusement = Console.ReadLine();
                        AmusementParks contentToDeleteAmusement = _amusementRepo.GetContentByTitle(titleToDeleteAmusement);
                        bool wasDeletedAmusement = _amusementRepo.DeleteExistingContent(contentToDeleteAmusement);
                        if (wasDeletedAmusement)
                        {
                            Console.WriteLine("This content was successfully deleted.");
                        }
                        else
                        {
                            Console.WriteLine("Content could not be deleted");
                        }
                        break;
                    case "5":

                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void DisplayContent(IEvent content)
        {
            Console.WriteLine($"Event Name: {content.NameOfEvent}");
            Console.WriteLine($"Number of people at the event: {content.NumberOfPeople}");
            Console.WriteLine($"Price paid per person: {content.CostPerPerson}");
            Console.WriteLine($"Total cost of event: {content.CostOfEntireEvent}");
            Console.WriteLine($"Date the event takes place: {content.Date}");
            Console.WriteLine($"Sum cost of all events: {content.CostOfAllEvents}");

        }

    }
}

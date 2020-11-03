using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_OutingsRepo.Ievents
{
    public class Bowling : IEvent
    {
        public string NameOfEvent { get; set; }
        public int NumberOfPeople { get; set; }
        public double CostPerPerson { get; set; }
        public double CostOfEntireEvent { get; set; }
        public  DateTime Date { get; set; }
        public double CostOfAllEvents { get; set; }

        /*
         *  //
        // Declare two collections of int elements.
        //
        int[] array1 = { 1, 3, 5, 7 };
        List<int> list1 = new List<int>() { 1, 3, 5, 7 };

        //
        // Use Sum extension on their elements.
        //
        int sum1 = array1.Sum();
        int sum2 = list1.Sum();

        //
        // Write results to screen.
        //
        Console.WriteLine(sum1);
        Console.WriteLine(sum2);
         */



        public Bowling() { }

        public Bowling(string nameOfEvent, int numberOfPeople, double costPerPerson, double costOfEntireEvent, DateTime date, double costOfAllEvents)
        {
            NameOfEvent = nameOfEvent;
            NumberOfPeople = numberOfPeople;
            CostPerPerson = costPerPerson;
            CostOfEntireEvent = costOfEntireEvent;
            Date = date;
            CostOfAllEvents = costOfAllEvents;
        }

        private List<Bowling> _contentDirectory = new List<Bowling>();



        public bool AddContentToDirectory(Bowling content)
        {
            int startingCount = _contentDirectory.Count;



            _contentDirectory.Add(content);
           
            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<Bowling> GetContents()
        {
            return _contentDirectory;
        }

        public Bowling GetContentByTitle(string title)
        {
            foreach (Bowling content in _contentDirectory)
            {
                if (content.NameOfEvent.ToLower() == title.ToLower())
                {
                    return content;
                }
            }
            return null;
        }

        public bool UpdateExistingContent(string originalTitle, Bowling newContent)
        {
            Bowling oldContent = GetContentByTitle(originalTitle);

            if (oldContent != null)
            {
                oldContent.NameOfEvent = newContent.NameOfEvent;
                oldContent.NumberOfPeople = newContent.NumberOfPeople;
                oldContent.CostPerPerson = newContent.CostPerPerson;
                oldContent.CostOfEntireEvent = newContent.CostOfEntireEvent;
                oldContent.Date = newContent.Date;
                oldContent.CostOfAllEvents = newContent.CostOfAllEvents;
               
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteExistingContent(Bowling existingContent)
        {
            bool deleteResult = _contentDirectory.Remove(existingContent);
            return deleteResult;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_OutingsRepo.Ievents
{
    public class Concerts : IEvent
    {
        public string NameOfEvent { get; set; }
        public int NumberOfPeople { get; set; }
        public double CostPerPerson { get; set; }
        public double CostOfEntireEvent { get; set; }
        public double CostOfAllEvents { get; set; }
        public DateTime Date { get; set; }
        public Concerts() { }

        public Concerts(string nameOfEvent, int numberOfPeople, double costPerPerson, double costOfEntireEvent, DateTime date, double costOfAllEvents)
        {
            NameOfEvent = nameOfEvent;
            NumberOfPeople = numberOfPeople;
            CostPerPerson = costPerPerson;
            CostOfEntireEvent = costOfEntireEvent;
            Date = date;
            CostOfAllEvents = costOfAllEvents;
        }

        private List<Concerts> _contentDirectory = new List<Concerts>();



        public bool AddContentToDirectory(Concerts content)
        {
            int startingCount = _contentDirectory.Count;



            _contentDirectory.Add(content);

            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<Concerts> GetContents()
        {
            return _contentDirectory;
        }

        public Concerts GetContentByTitle(string title)
        {
            foreach (Concerts content in _contentDirectory)
            {
                if (content.NameOfEvent.ToLower() == title.ToLower())
                {
                    return content;
                }
            }
            return null;
        }

        public bool UpdateExistingContent(string originalTitle, Concerts newContent)
        {
            Concerts oldContent = GetContentByTitle(originalTitle);

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

        public bool DeleteExistingContent(Concerts existingContent)
        {
            bool deleteResult = _contentDirectory.Remove(existingContent);
            return deleteResult;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_OutingsRepo.Ievents
{
    public class Golf : IEvent
    {
        public string NameOfEvent { get; set; }
        public int NumberOfPeople { get; set; }
        public double CostPerPerson { get; set; }
        public double CostOfEntireEvent { get; set; }
        public DateTime Date { get; set; }
        public double CostOfAllEvents { get; set; }
        public Golf() { }

        public Golf(string nameOfEvent, int numberOfPeople, double costPerPerson, double costOfEntireEvent, DateTime date, double costOfAllEvents)
        {
            NameOfEvent = nameOfEvent;
            NumberOfPeople = numberOfPeople;
            CostPerPerson = costPerPerson;
            CostOfEntireEvent = costOfEntireEvent;
            Date = date;
            CostOfAllEvents = costOfAllEvents;
        }

        private List<Golf> _contentDirectory = new List<Golf>();



        public bool AddContentToDirectory(Golf content)
        {
            int startingCount = _contentDirectory.Count;



            _contentDirectory.Add(content);

            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<Golf> GetContents()
        {
            return _contentDirectory;
        }

        public Golf GetContentByTitle(string title)
        {
            foreach (Golf content in _contentDirectory)
            {
                if (content.NameOfEvent.ToLower() == title.ToLower())
                {
                    return content;
                }
            }
            return null;
        }

        public bool UpdateExistingContent(string originalTitle, Golf newContent)
        {
            Golf oldContent = GetContentByTitle(originalTitle);

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

        public bool DeleteExistingContent(Golf existingContent)
        {
            bool deleteResult = _contentDirectory.Remove(existingContent);
            return deleteResult;
        }
    }
}


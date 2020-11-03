using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_OutingsRepo
{
    public interface IEvent
    {
        string NameOfEvent { get; set; }
        int NumberOfPeople { get; set; }
        double CostPerPerson { get; set; }
        double CostOfEntireEvent { get; set; }
        DateTime Date { get; set; }
        double CostOfAllEvents { get; set; }
        


        
    }
}

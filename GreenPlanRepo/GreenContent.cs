using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPlanRepo
{
    public class GreenContent
    {
        //public string CarType { get; set; }
        public CarType CarType { get; set; }
        public string CarName { get; set; }
        public int MileageToRefill { get; set; }
        public int YearMade { get; set; }
        public int CarPrice { get; set; }

        //public List<GreenContent> GasCar { get; set; }
        //public List<GreenContent> ElectricCar { get; set; }
        //public List<GreenContent> HybridCar { get; set; }

        /*public bool IsFamilyFriendly
        {
            get
            {
                switch (MaturityRating)
                {
                    case MaturityRating.G:
                    case MaturityRating.PG:
                    case MaturityRating.PG_13:
                        return true;
                    case MaturityRating.R:
                    case MaturityRating.NC_17:
                    default: return false;
                }
            }
        }*/

        public GreenContent() { }

        public GreenContent(CarType carType, string carName, int mileageToRefill, int yearMade, int carPrice)
        {
            CarType = carType;
            CarName = carName;
            MileageToRefill = mileageToRefill;
            YearMade = yearMade;
            CarPrice = carPrice;
           
        }


       
    }

    public enum CarType
    {
        Gas = 1,
        Electric,
        Hybrid
    }

}

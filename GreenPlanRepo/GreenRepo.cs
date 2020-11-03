using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPlanRepo
{
    public class GreenRepo
    {
        private List<GreenContent> _contentDirectory = new List<GreenContent>();
       


        public bool AddContentToDirectory(GreenContent content)
        {
            int startingCount = _contentDirectory.Count;
            
            

            _contentDirectory.Add(content);

            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<GreenContent> GetContents()
        {
            return _contentDirectory;
        }

        public GreenContent GetContentByTitle(string title)
        {
            foreach (GreenContent content in _contentDirectory)
            {
                if (content.CarName.ToLower() == title.ToLower())
                {
                    return content;
                }
            }
            return null;
        }

        public bool UpdateExistingContent(string originalTitle, GreenContent newContent)
        {
            GreenContent oldContent = GetContentByTitle(originalTitle);

            if (oldContent != null)
            {
                oldContent.CarName = newContent.CarName;
                oldContent.MileageToRefill = newContent.MileageToRefill;
                oldContent.YearMade = newContent.YearMade;
                oldContent.CarPrice = newContent.CarPrice;
                oldContent.CarType = newContent.CarType;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteExistingContent(GreenContent existingContent)
        {
            bool deleteResult = _contentDirectory.Remove(existingContent);
            return deleteResult;
        }
    }
}

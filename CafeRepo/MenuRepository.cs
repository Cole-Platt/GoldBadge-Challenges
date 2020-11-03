using CafeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepo
{
    public class MenuRepository
    {
        private List<MenuContent> _contentDirectory = new List<MenuContent>();
        public bool AddContentToDirectory(MenuContent content)
        {
            int startingCount = _contentDirectory.Count;

            _contentDirectory.Add(content);

            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public List<MenuContent> GetContents()
        {
            return _contentDirectory;
        }

        public MenuContent GetContentByTitle(string title)
        {
            foreach (MenuContent content in _contentDirectory)
            {
                if (content.MealName.ToLower() == title.ToLower())
                {
                    return content;
                }
            }
            return null;
        }

        public bool DeleteExistingContent(MenuContent existingContent)
        {
            bool deleteResult = _contentDirectory.Remove(existingContent);
            return deleteResult;
        }
       
    }
}

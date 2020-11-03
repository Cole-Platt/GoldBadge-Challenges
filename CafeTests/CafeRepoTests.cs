using System;
using System.Collections.Generic;
using CafeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CafeTests
{
    [TestClass]
    public class CafeRepoTests
    {


        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBoolean()
        {
            //Arrange
            MenuContent content = new MenuContent();
            MenuRepository repository = new MenuRepository();

            //Act
            bool addResult = repository.AddContentToDirectory(content);

            //Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectCollection()
        {
            //Arrange
            MenuContent content = new MenuContent();
            MenuRepository repo = new MenuRepository();

            repo.AddContentToDirectory(content);

            //Act
            List<MenuContent> contents = repo.GetContents();

            bool directoryHasContent = contents.Contains(content);

            //Assert
            Assert.IsTrue(directoryHasContent);
        }

        [TestMethod]
        public void GetByTitle_ShouldReturnCorrectContent()
        {
            //Arrange
            MenuRepository repo = new MenuRepository();
            MenuContent newContent = new MenuContent("Cheese Burger", "A simple classic", 1, 5, "Beef, Cheese, Bread");
            repo.AddContentToDirectory(newContent);
            string title = "Cheese Burger";

            //Act
            MenuContent searchResult = repo.GetContentByTitle(title);
            //Assert
            Assert.AreEqual(searchResult.MealName, title);
        }
        [TestMethod]
        public void DeleteExistingContent_ShouldReturnTrue()
        {
            //Arrange
            MenuRepository repo = new MenuRepository();
            MenuContent content = new MenuContent("Cheese Burger", "A simple classic", 1, 5, "Beef, Cheese, Bread");

            repo.AddContentToDirectory(content);

            //Act
            MenuContent oldContent = repo.GetContentByTitle("Cheese Burger");

            bool removeResult = repo.DeleteExistingContent(oldContent);

            //Assert
            Assert.IsTrue(removeResult);
        }

    }
}

using System;
using System.Collections.Generic;
using GreenPlanRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _06_GreenPlanTest
{
    [TestClass]
    public class UnitTest1
    {



        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBoolean()
        {
            //Arrange
            GreenContent content = new GreenContent();
            GreenRepo repository = new GreenRepo();

            //Act
            bool addResult = repository.AddContentToDirectory(content);

            //Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectCollection()
        {
            //Arrange
            GreenContent content = new GreenContent();
            GreenRepo repo = new GreenRepo();

            repo.AddContentToDirectory(content);

            //Act
            List<GreenContent> contents = repo.GetContents();

            bool directoryHasContent = contents.Contains(content);

            //Assert
            Assert.IsTrue(directoryHasContent);
        }

        [TestMethod]
        public void GetByTitle_ShouldReturnCorrectContent()
        {
            //Arrange
            GreenRepo repo = new GreenRepo();
            GreenContent newContent = new GreenContent();
            repo.AddContentToDirectory(newContent);
            string title = "";

            //Act
            GreenContent searchResult = repo.GetContentByTitle(title);
            //Assert
            Assert.AreEqual(searchResult.CarName, title);
        }

        [TestMethod]
        public void UpdateExistingContent_ShouldReturnTrue()
        {
            //Arrange
            GreenRepo repo = new GreenRepo();
            GreenContent oldContent = new GreenContent();
            repo.AddContentToDirectory(oldContent);

            GreenContent newContent = new GreenContent();

            //Act
            bool updateResult = repo.UpdateExistingContent(oldContent.CarName, newContent);

            //Assert
            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void DeleteExistingContent_ShouldReturnTrue()
        {
            //Arrange
            GreenRepo repo = new GreenRepo();
            GreenContent content = new GreenContent();
            repo.AddContentToDirectory(content);

            //Act
            GreenContent oldContent = repo.GetContentByTitle();

            bool removeResult = repo.DeleteExistingContent(oldContent);

            //Assert
            Assert.IsNull(removeResult);
        }
    }
}






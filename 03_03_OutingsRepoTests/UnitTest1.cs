using System;
using System.Collections.Generic;
using _07_OutingsRepo;
using _07_OutingsRepo.Ievents;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_03_OutingsRepoTests
{
    [TestClass]
    public class UnitTest1
    {



        [TestMethod]
        public void AddToDirectory_ShouldGetCorrectBoolean()
        {
            //Arrange
            Bowling content = new Bowling();
            Bowling repository = new Bowling();

            //Act
            bool addResult = repository.AddContentToDirectory(content);

            //Assert
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetDirectory_ShouldReturnCorrectCollection()
        {
            //Arrange
            Bowling content = new Bowling();
            Bowling repo = new Bowling();

            repo.AddContentToDirectory(content);

            //Act
            List<Bowling> contents = repo.GetContents();

            bool directoryHasContent = contents.Contains(content);

            //Assert
            Assert.IsTrue(directoryHasContent);
        }

        [TestMethod]
        public void GetByTitle_ShouldReturnCorrectContent()
        {
            //Arrange
            Bowling repo = new Bowling();
            Bowling newContent = new Bowling();
            repo.AddContentToDirectory(newContent);
            string title = "";

            //Act
            Bowling searchResult = repo.GetContentByTitle(title);
            //Assert
            Assert.AreEqual(searchResult.NameOfEvent, title);
        }

        [TestMethod]
        public void UpdateExistingContent_ShouldReturnTrue()
        {
            //Arrange
            Bowling repo = new Bowling();
            Bowling oldContent = new Bowling();
            repo.AddContentToDirectory(oldContent);

            Bowling newContent = new Bowling();

            //Act
            bool updateResult = repo.UpdateExistingContent(oldContent.NameOfEvent, newContent);

            //Assert
            Assert.IsTrue(updateResult);
        }

        [TestMethod]
        public void DeleteExistingContent_ShouldReturnTrue()
        {
            //Arrange
            Bowling repo = new Bowling();
            Bowling content = new Bowling();
            repo.AddContentToDirectory(content);

            //Act
            Bowling oldContent = repo.GetContentByTitle("Bowling");

            bool removeResult = repo.DeleteExistingContent(oldContent);

            //Assert
            Assert.IsNull(removeResult);
        }
    }
}

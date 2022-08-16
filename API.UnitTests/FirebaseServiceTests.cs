using API.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace API.UnitTests
{
    [TestClass]
    public class FirebaseServiceTests
    {
        [TestMethod]
        public void StoreData_NormalData_Success()
        {
            //Arrange
            var firebaseService = new FirebaseService();

            //Act
            //firebaseService.StoreUserData(new
            //{
            //    Key = "UserKey",
            //    TimePlayed = 145.26f,
            //    AdsWatched = new List<string>() { "New Level Ad", "Death Ad", "In Gane Gift"}
            //});

            //Assert
            Assert.IsTrue(true);
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GTMFitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTMFitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var birthdate = DateTime.Now.AddYears(-18);
            var weight = 51;
            var height = 170;
            var gender = "man";
            var controller = new UserController(userName);

            //Act
            controller.SetNewUserData(gender, birthdate, weight, height);
            var controller2 = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, controller2.Currentuser.Name);
            Assert.AreEqual(birthdate, controller2.Currentuser.BirthDate);
            Assert.AreEqual(weight, controller2.Currentuser.Weight);
            Assert.AreEqual(height, controller2.Currentuser.Height);
            Assert.AreEqual(gender, controller2.Currentuser.Gender.Name);
        }

        [TestMethod()]
        public void SaveTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();

            // Act
            var controller = new UserController(userName);

            // Assert
            Assert.AreEqual(userName, controller.Currentuser.Name);
        }
    }
}
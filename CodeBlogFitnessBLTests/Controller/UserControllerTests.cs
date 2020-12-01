using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBlogFitnessBL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitnessBL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            var userName = Guid.NewGuid().ToString();
            var birthdate = DateTime.Now.AddYears(- 18);
            var weight = 90;
            var height = 190;
            var gender = "man";
            var controller = new UserController(userName);
            controller.SetNewUserData(gender, birthdate, weight, height);
            var controller2= new UserController(userName);
            Assert.AreEqual(userName, controller2.CurrrentUser.Name);
        }

        [TestMethod()]
        public void SaveTest()
        {
            var userName = Guid.NewGuid().ToString();
            var controller = new UserController(userName);
            Assert.AreEqual(userName, controller.CurrrentUser.Name);
        }

        [TestMethod()]
        public void UserControllerTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetNewUserDataTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveTest1()
        {
            Assert.Fail();
        }
    }
}
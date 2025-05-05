using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using Apotekku_API.Controllers;
using Apotekku_API.Models;

namespace TestApotik
{
    [TestClass]
    public class UserControllerLoginTest
    {
        [TestMethod]
        public void Login_Mantap()
        {
            
            var controller = new UserController();
            var loginUser = new User { Nama = "jidan", Password = "jidanbauk" };

            
            var result = controller.Login(loginUser);

            
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Login_Salah()
        {
            
            var controller = new UserController();
            var loginUser = new User { Nama = "jidan", Password = "salah" };

            
            var result = controller.Login(loginUser);

            
            Assert.IsInstanceOfType(result, typeof(UnauthorizedObjectResult));
        }
    }
}

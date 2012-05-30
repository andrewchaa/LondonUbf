using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using LondonUbfMvc;
using LondonUbfMvc.Controllers;
using NUnit.Framework;

namespace LondonUbfMvc.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index()
        {
            // Arrange
            RotaController controller = new RotaController();

            // Act
            ViewResult result = controller.Index(1) as ViewResult;

            // Assert
            ViewDataDictionary viewData = result.ViewData;
            Assert.AreEqual("Welcome to ASP.NET MVC!", viewData["Message"]);
        }
    }
}

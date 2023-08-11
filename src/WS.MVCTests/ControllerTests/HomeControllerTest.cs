using WS.MVC.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WS.MVCTests.ControllerTests
{
    public class HomeControllerTest
    {
        private readonly HomeController controller;
        public HomeControllerTest() => controller = new HomeController();

        [Fact]
        public void Home_Index_Test()
        {
            Assert.Equal("Index", (controller.Index() as ViewResult)?.ViewName);
        }

        [Fact]
        public void Home_Privacy_Test()
        {
            Assert.Equal("Privacy", (controller.Privacy() as ViewResult)?.ViewName);
        }
    }
}
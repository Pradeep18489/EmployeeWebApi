using System;
using EmployeeWebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Web.Http;
using EmployeeWebApi.Services;
using Moq;
using System.Collections.Generic;
using EmployeeWebApi.Data;

namespace EmployeeWebApi.Tests.Controllers
{
    [TestClass]
    public class EmployeeControllerTests
    {
        [TestMethod]
        public void TestGetAllEmployees()
        {
            // Set up Prerequisites   
            var controller = new EmployeeController(new Mock<IEmployeeService>().Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act on Test  
            var response = controller.Get();
            // Assert the result  
            Assert.AreEqual(typeof(List<Employee>),response.GetType()); 
        }
    }
}

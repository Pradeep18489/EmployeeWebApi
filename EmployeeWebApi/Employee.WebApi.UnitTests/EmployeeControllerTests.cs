using System;
using EmployeeWebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Web.Http;
using EmployeeWebApi.Services;
using Moq;
using System.Collections.Generic;
using System.Net;
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
            var employeeServiceMock =  new Mock<IEmployeeService>();
            employeeServiceMock.Setup(e => e.GetEmployees()).Returns(new List<Employee>());
            var controller = new EmployeeController(employeeServiceMock.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act on Test  
            var response = controller.Get();
            // Assert the result  
            Assert.AreEqual(typeof(List<Employee>), response.GetType());
        }

        [TestMethod]
        public void TesPostMethod()
        {
            // Set up Prerequisites   
            var employeeServiceMock = new Mock<IEmployeeService>();
            var controller = new EmployeeController(employeeServiceMock.Object);
            controller.Request = new HttpRequestMessage();
            UriBuilder uriBuilder = new UriBuilder();
            uriBuilder.Scheme = "http";
            uriBuilder.Host = "cnn.com";
            uriBuilder.Path = "americas";
            Uri uri = uriBuilder.Uri;
            controller.Request.RequestUri = uriBuilder.Uri;
            controller.Configuration = new HttpConfiguration();
            // Act on Test  
            var response = controller.Post(new Employee(){EmployeeId = 1});
            // Assert the result  
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public void TestDeleteMethod_isDeletedTrue()
        {
            // Set up Prerequisites   
            var employeeServiceMock = new Mock<IEmployeeService>();
            employeeServiceMock.Setup(e => e.Remove(1)).Returns(true);
            var controller = new EmployeeController(employeeServiceMock.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act on Test  
            var response = controller.Delete(1);
            // Assert the result  
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void TestDeleteMethod_isDeletedFalse()
        {
            // Set up Prerequisites   
            var employeeServiceMock = new Mock<IEmployeeService>();
            employeeServiceMock.Setup(e => e.Remove(1)).Returns(false);
            var controller = new EmployeeController(employeeServiceMock.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
            // Act on Test  
            var response = controller.Delete(1);
            // Assert the result  
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}

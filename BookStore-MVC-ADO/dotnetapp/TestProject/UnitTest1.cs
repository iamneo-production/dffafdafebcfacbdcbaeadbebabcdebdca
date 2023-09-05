using NUnit.Framework;
using dotnetapp.Controllers;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using Moq;
using System.Data;
using System.Data.SqlClient;


namespace BookControllerTests
{
    [TestFixture]
    public class BookControllerTests
    {
        private BookController _controller;
        private Type controllerType;
        private Type carserviceType;
        private PropertyInfo[] properties;

        [SetUp]
        public void Setup()
        {
            // Initialize the controller before each test
            _controller = new BookController();
            carserviceType = typeof(dotnetapp.Models.Book);
            properties = carserviceType.GetProperties();
            controllerType = typeof(BookController);
        }

        [Test]
        public void Test_IndexReturns_ViewResult()
        {
            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsAssignableFrom<List<Book>>(result.Model);
        }
    }
}
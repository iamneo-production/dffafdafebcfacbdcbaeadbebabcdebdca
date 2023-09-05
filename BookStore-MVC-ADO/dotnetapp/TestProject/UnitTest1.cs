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
        [Test]
        public void Test_CreateReturns_ViewResult()
        {
            // Act
            var result = _controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
public void TestIndexMethodExists()
{
    // Arrange
    var controllerType = typeof(BookController);
    var methodName = "Index";

    // Act
    var indexMethod = controllerType.GetMethod(methodName);

    // Assert
    Assert.IsNotNull(indexMethod, $"{methodName} method should exist in BookController.");
}

        [Test]
        public void TestCreateGetMethodExists()
        {
            // Arrange
            MethodInfo createGetMethod = controllerType.GetMethod("Create", new Type[0]);

            // Assert
            Assert.IsNotNull(createGetMethod, "Create method should exist in BookController.");
        }

        [Test]
        public void TestCreatePostMethodExists()
        {
            // Arrange
            MethodInfo createPostMethod = controllerType.GetMethod("Create", new Type[] { typeof(Book) });

            // Assert
            Assert.IsNotNull(createPostMethod, "Create POST method should exist in BookController.");
        }

        [Test]
        public void TestBookClassExists()
        {
            // Arrange
            Type furnitureType = typeof(dotnetapp.Models.Book);

            // Assert
            Assert.IsNotNull(furnitureType, "Book class should exist.");            
        }

        [Test]
        public void TestBookPropertiesExist()
        {
            // Assert
            Assert.IsNotNull(properties, "Book class should have properties.");
            Assert.IsTrue(properties.Length > 0, "Book class should have at least one property.");
        }

        [Test]
        public void TestidProperty()
        {
            // Arrange
            PropertyInfo idProperty = properties.FirstOrDefault(p => p.Name == "id");

            // Assert
            Assert.IsNotNull(idProperty, "id property should exist.");
            Assert.AreEqual(typeof(int), idProperty.PropertyType, "id property should have data type 'int'.");
        }

        [Test]
        public void TestNameProperty()
        {
            // Arrange
            PropertyInfo productProperty = properties.FirstOrDefault(p => p.Name == "Name");

            // Assert
            Assert.IsNotNull(productProperty, "Name property should exist.");
            Assert.AreEqual(typeof(string), productProperty.PropertyType, "Name property should have data type 'string'.");
        }
    }
}
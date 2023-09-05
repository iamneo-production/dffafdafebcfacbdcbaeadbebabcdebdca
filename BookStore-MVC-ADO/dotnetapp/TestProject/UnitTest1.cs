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
        public void TestBookIDProperty()
        {
            // Arrange
            PropertyInfo idProperty = properties.FirstOrDefault(p => p.Name == "BookID");

            // Assert
            Assert.IsNotNull(idProperty, "BookID property should exist.");
            Assert.AreEqual(typeof(int), idProperty.PropertyType, "BookID property should have data type 'int'.");
        }

        [Test]
        public void TestTitleProperty()
        {
            // Arrange
            PropertyInfo productProperty = properties.FirstOrDefault(p => p.Name == "Title");

            // Assert
            Assert.IsNotNull(productProperty, "Title property should exist.");
            Assert.AreEqual(typeof(string), productProperty.PropertyType, "Title property should have data type 'string'.");
        }

        [Test]
        public void TestPriceProperty()
        {
            // Arrange
            PropertyInfo productProperty = properties.FirstOrDefault(p => p.Name == "Price");

            // Assert
            Assert.IsNotNull(productProperty, "Price property should exist.");
            Assert.AreEqual(typeof(decimal), productProperty.PropertyType, "Price property should have data type 'string'.");
        }
        [Test]
        public void TestQuantityProperty()
        {
            // Arrange
            PropertyInfo productProperty = properties.FirstOrDefault(p => p.Name == "Quantity");

            // Assert
            Assert.IsNotNull(productProperty, "Quantity property should exist.");
            Assert.AreEqual(typeof(int), productProperty.PropertyType, "Quantity property should have data type 'string'.");
        }

        [Test]
        public void Test_CreateViewFile_Exists()
        {
            string indexPath = Path.Combine(@"/home/coder/project/workspace/BookStore-MVC-ADO/dotnetapp/Views/Book", "Create.cshtml");
            bool indexViewExists = File.Exists(indexPath);

            Assert.IsTrue(indexViewExists, "Create.cshtml view file does not exist.");
        }

        [Test]
        public void Test_IndexViewFile_Exists()
        {
            string indexPath = Path.Combine(@"/home/coder/project/workspace/BookStore-MVC-ADO/dotnetapp/Views/Book", "Index.cshtml");
            bool indexViewExists = File.Exists(indexPath);

            Assert.IsTrue(indexViewExists, "Index.cshtml view file does not exist.");
        }
    }
}
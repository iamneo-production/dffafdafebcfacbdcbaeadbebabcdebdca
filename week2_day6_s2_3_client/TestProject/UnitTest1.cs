using System;
using System.Reflection;
using NUnit.Framework;
using dotnetapp.Models;
using dotnetapp.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Moq;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace dotnetapp.Tests
{
    [TestFixture]
    public class PostTests
    {
        // private const string ViewsFolderPath = "Views";
        // private const string PostViewsFolderPath = "D:\\Visual Studio\\W5_D1_S1_Client\\dotnetapp\\dotnetapp\\Views\\Post";
        private Type _productType;
        private Type controllerType;
        private Type _viewType;
        private Assembly _assembly1;
        private string relativeFolderPath; // Set this to the relative path of the folder you want to check
        private string fileName; 
        private Mock<OrdersDbContext> _mockContext;
        private OrderController _controller;

        // private PostController _postcontroller;
        // private List<Post> _fakePosts;


        [SetUp]
        public void Setup()
        {
            
            // _mockContext = new Mock<OrdersDbContext>();
            // _controller = new OrderController(_mockContext.Object);
            //_postcontroller = new PostController();
           
        }

        [TearDown]
        public void TearDown()
        {
            //_postcontroller = null;
        }

        private static MethodInfo GetMethod(Type type, string methodName, Type[] parameterTypes)
        {
            return type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance, null, parameterTypes, null);
        }


        [Test]
        public void Session_2_TestProduct_ClassExists()
        {
            // Load the assembly at runtime
            Assembly assembly = Assembly.Load("dotnetapp");
            Type postType = assembly.GetType("dotnetapp.Models.Product");
            Assert.NotNull(postType, "Product class does not exist.");
        }
        [Test]
        public void Session_2_TestCategory_ClassExists()
        {
            // Load the assembly at runtime
            Assembly assembly = Assembly.Load("dotnetapp");
            Type postType = assembly.GetType("dotnetapp.Models.Category");
            Assert.NotNull(postType, "Category class does not exist.");
        }
        [Test]
        public void Session_2_TestOrder_ClassExists()
        {
            // Load the assembly at runtime
            Assembly assembly = Assembly.Load("dotnetapp");
            Type postType = assembly.GetType("dotnetapp.Models.Order");
            Assert.NotNull(postType, "Order class does not exist.");
        }
        [Test]
        public void Session_2_TestCustomer_ClassExists()
        {
            // Load the assembly at runtime
            Assembly assembly = Assembly.Load("dotnetapp");
            Type postType = assembly.GetType("dotnetapp.Models.Customer");
            Assert.NotNull(postType, "Customer class does not exist.");
        }
        [Test]
        public void Session_2_TestOrderDetail_ClassExists()
        {
            // Load the assembly at runtime
            Assembly assembly = Assembly.Load("dotnetapp");
            Type postType = assembly.GetType("dotnetapp.Models.OrderDetail");
            Assert.NotNull(postType, "OrderDetails class does not exist.");
        }
        [Test]
        public void Session_2_TestOrdersDbContext_ClassExists()
        {
            // Load the assembly at runtime
            Assembly assembly = Assembly.Load("dotnetapp");
            Type postType = assembly.GetType("dotnetapp.Models.OrdersDbContext");
            Assert.NotNull(postType, "OrdersDbContext class does not exist.");
        }

        [Test]
        public void Session_2_TestUnitPricePropertyType()
        {
            Assembly assembly = Assembly.Load("dotnetapp");
            _productType = assembly.GetType("dotnetapp.Models.Product");
            PropertyInfo UnitPriceProperty = _productType.GetProperty("UnitPrice");
            Assert.NotNull(UnitPriceProperty, "UnitPrice property does not exist.");
            Assert.AreEqual(typeof(decimal), UnitPriceProperty.PropertyType, "UnitPrice property should be of type DateTime.");
        }

        [Test]
        public void Session_2_TestDiscountPropertyType_OrderDetail_table()
        {
            Assembly assembly = Assembly.Load("dotnetapp");
            _productType = assembly.GetType("dotnetapp.Models.OrderDetail");
            PropertyInfo DiscountProperty = _productType.GetProperty("Discount");
            Assert.NotNull(DiscountProperty, "Discount property does not exist.");
            Assert.AreEqual(typeof(float), DiscountProperty.PropertyType, "Discount property should be of type float.");
        }

        [Test]
        public void Session_2_TestPicturePropertyType_Category_Table()
        {
            Assembly assembly = Assembly.Load("dotnetapp");
            _productType = assembly.GetType("dotnetapp.Models.Category");
            PropertyInfo PictureProperty = _productType.GetProperty("Picture");
            Assert.NotNull(PictureProperty, "Picture property does not exist.");
            Assert.AreEqual(typeof(byte[]), PictureProperty.PropertyType, "Picture property should be of type byte[].");
        }

        [Test]
        public void Session_2_TestMigrationExists()
        {
            bool viewsFolderExists = Directory.Exists(@"/home/coder/project/workspace/week2_day6_s2_3_client/dotnetapp/Migrations");

            Assert.IsTrue(viewsFolderExists, "Post folder does not exist.");
        }


        // [Test]
        // public void DisplayCustomers_ReturnsViewWithCustomers()
        // {
        //     // Arrange
        //     var customers = new List<Customer>
        //     {
        //         new Customer { CustomerID = "C1", CompanyName = "Company 1" },
        //         new Customer { CustomerID = "C2", CompanyName = "Company 2" }
        //     };

        //     var mockSet = new Mock<DbSet<Customer>>();
        //     mockSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(customers.AsQueryable().Provider);
        //     mockSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(customers.AsQueryable().Expression);
        //     mockSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(customers.AsQueryable().ElementType);
        //     mockSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(customers.GetEnumerator());

        //     _mockContext.Setup(context => context.Customers).Returns(mockSet.Object);

        //     // Act
        //     var result = _controller.DisplayCustomers() as ViewResult;
        //     var model = result?.Model as List<Customer>;

        //     // Assert
        //     Assert.IsNotNull(result);
        //     Assert.IsNotNull(model);
        //     Assert.AreEqual(customers.Count, model.Count);
        // }

        [Test]
        public void Session_2_Test_DisplayCustomers_Action()
        {
            Assembly assembly = Assembly.Load("dotnetapp");
            controllerType = assembly.GetType("dotnetapp.Controllers.OrderController");
            var detailsMethod = GetMethod(controllerType, "DisplayCustomers", new Type[] {  });

            Assert.NotNull(detailsMethod);
        }
    }
}

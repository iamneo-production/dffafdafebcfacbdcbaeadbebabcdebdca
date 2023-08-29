using System;
using System.Reflection;
using NUnit.Framework;
using dotnetapp.Models;
// using dotnetapp.Controllers;
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
        // private PostController _postcontroller;
        // private List<Post> _fakePosts;


        [SetUp]
        public void Setup()
        {
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
        public void Session_1_TestUnitPricePropertyType()
        {
            Assembly assembly = Assembly.Load("dotnetapp");
            _productType = assembly.GetType("dotnetapp.Models.Product");
            PropertyInfo UnitPriceProperty = _productType.GetProperty("UnitPrice");
            Assert.NotNull(UnitPriceProperty, "UnitPrice property does not exist.");
            Assert.AreEqual(typeof(decimal), UnitPriceProperty.PropertyType, "UnitPrice property should be of type DateTime.");
        }
    }
}

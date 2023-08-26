using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;


namespace dotnetapp.Tests
{
    [TestFixture]
    public class StudentTests
    {
        private Type _studentType;
        private PropertyInfo[] _studentProperties; 
        private Type _controllerType;
        private ApplicationDbContext _context;
        private HttpClient _client;



        [SetUp]
        public void Setup()
        {
            _studentType = new Student().GetType();
            _studentProperties = _studentType.GetProperties();
            _controllerType = typeof(StudentsController);
            _context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());

            _client = new HttpClient();
            _client.BaseAddress = new System.Uri("http://localhost:8080/");


        }

        [Test]
        public async Task GetStudents_ReturnsSuccess()
        {
            HttpResponseMessage response = await _client.GetAsync("api/Students");
            // Assert that the response status code is 200 OK.
            Console.WriteLine(response.StatusCode);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            // Assert that the response content is not empty.
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            Assert.IsNotEmpty(responseBody);
        }

        [Test]
        public async Task PostStudents_ReturnsSuccess() {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/api/Students");
            request.Content = new StringContent("{\"name\": \"DemoTest\",\"department\": \"MCA\",\"phoneNumber\": \"9845612372\"}",
            Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.SendAsync(request);
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            string responseBody = await response.Content.ReadAsStringAsync();
            Assert.IsNotEmpty(responseBody);
        }

        [Test]
        public void Test_Student_Class_Exists()
        {
            Assert.NotNull(_studentType);
        }

        [Test]
        public void Test_Student_Id_Property_DataType()
        {
            var idProperty = _studentProperties.FirstOrDefault(prop => prop.Name == "Id");
            Assert.NotNull(idProperty);
            Assert.AreEqual(typeof(int), idProperty.PropertyType);
        }

        [Test]
        public void Test_Student_Name_Property_DataType()
        {
            var nameProperty = _studentProperties.FirstOrDefault(prop => prop.Name == "Name");
            Assert.NotNull(nameProperty);
            Assert.AreEqual(typeof(string), nameProperty.PropertyType);
        }

        [Test]
        public void Test_Student_Department_Property_DataType()
        {
            var departmentProperty = _studentProperties.FirstOrDefault(prop => prop.Name == "Department");
            Assert.NotNull(departmentProperty);
            Assert.AreEqual(typeof(string), departmentProperty.PropertyType);
        }

        [Test]
        public void Test_Student_PhoneNumber_Property_DataType()
        {
            var phoneNumberProperty = _studentProperties.FirstOrDefault(prop => prop.Name == "PhoneNumber");
            Assert.NotNull(phoneNumberProperty);
            Assert.AreEqual(typeof(string), phoneNumberProperty.PropertyType);
        }

        [Test]
        public void Test_StudentsController_Class_Exists()
        {
            Assert.NotNull(_controllerType);
        }

        [Test]
        public void Test_GetStudents_Method_Exists()
        {
            var methodInfo = _controllerType.GetMethod("GetStudents");
            Assert.NotNull(methodInfo);
        }

        [Test]
        public void Test_GetStudents_Method_HasHttpGetAttribute()
        {
            var methodInfo = _controllerType.GetMethod("GetStudents");
            var httpGetAttribute = methodInfo.GetCustomAttributes(typeof(HttpGetAttribute), true).FirstOrDefault();
            Assert.NotNull(httpGetAttribute);
        }

        [Test]
        public void Test_GetStudentById_Method_Exists()
        {
            var methodInfo = _controllerType.GetMethod("GetStudentById");
            Assert.NotNull(methodInfo);
        }

        [Test]
        public void Test_GetStudentById_Method_HasHttpGetAttribute()
        {
            var methodInfo = _controllerType.GetMethod("GetStudentById");
            var httpGetAttribute = methodInfo.GetCustomAttributes(typeof(HttpGetAttribute), true).FirstOrDefault();
            Assert.NotNull(httpGetAttribute);
        }

        [Test]
        public void Test_CreateStudent_Method_Exists()
        {
            var methodInfo = _controllerType.GetMethod("CreateStudent");
            Assert.NotNull(methodInfo);
        }

        [Test]
        public void Test_CreateStudent_Method_HasHttpPostAttribute()
        {
            var methodInfo = _controllerType.GetMethod("CreateStudent");
            var httpPostAttribute = methodInfo.GetCustomAttributes(typeof(HttpPostAttribute), true).FirstOrDefault();
            Assert.NotNull(httpPostAttribute);
        }
    }
}

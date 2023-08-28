using NUnit.Framework;
using dotnetapp.Models; // Adjust the namespace to match your project
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Reflection;



namespace dotnetapp.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private EMSDbContext _context;
        private Type _deptType;
        private Type _employeeType;
        private PropertyInfo[] _deptProperties;
        private PropertyInfo[] _employeeProperties;
        private DbContextOptions<EMSDbContext> _options1;




        [SetUp]
        public void Setup()
        {
            _deptType = new Dept().GetType();
            _employeeType = new Employee().GetType();
            _deptProperties = _deptType.GetProperties();
            _employeeProperties = _employeeType.GetProperties();

            // Set up the database context before running each test
            var options = new DbContextOptionsBuilder<EMSDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            // _options1 = new DbContextOptionsBuilder<EMSDbContext>()
            //     .UseInMemoryDatabase(databaseName: "TestDatabase1")
            //     .Options;

            _context = new EMSDbContext(options);

            // using (var context = new EMSDbContext(_options1))
            // {
            //     // Add test data to the in-memory database
            //     context.Employees.Add(new Employee
            //     {
            //         Id = 1,
            //         Name = "John Doe",
            //         Email = "john@example.com",
            //         Salary = 50000,
            //         Deptid = 1,
            //         Dateofbirth = new DateTime(1990, 1, 1)
            //     });

            //     context.SaveChanges();
            // }   
        }

        [Test]
        public void CreateDept_AddsDeptToDatabase()
        {
            // Arrange
            var dept = new Dept { Id = 1, Name = "Sample Department", Location = "Sample Location" };

            // Act
            _context.Depts.Add(dept);
            _context.SaveChanges();

            // Assert
            var addedDept = _context.Depts.Find(1);
            Assert.IsNotNull(addedDept);
            Assert.AreEqual("Sample Department", addedDept.Name);
        }

        [Test]
        public void Test_Dept_Class_Exists()
        {
            Assert.NotNull(_deptType);
        }

        [Test]
        public void Test_Employee_Class_Exists()
        {
            Assert.NotNull(_employeeType);
        }
        [Test]
        public void Test_Dept_Id_Property_DataType()
        {
            var idProperty = _deptProperties.FirstOrDefault(prop => prop.Name == "Id");
            Assert.NotNull(idProperty);
            Assert.AreEqual(typeof(int), idProperty.PropertyType);
        }

        [Test]
        public void Test_Dept_Name_Property_DataType()
        {
            var nameProperty = _deptProperties.FirstOrDefault(prop => prop.Name == "Name");
            Assert.NotNull(nameProperty);
            Assert.AreEqual(typeof(string), nameProperty.PropertyType);
        }

        [Test]
        public void Test_Dept_Location_Property_DataType()
        {
            var departmentProperty = _deptProperties.FirstOrDefault(prop => prop.Name == "Location");
            Assert.NotNull(departmentProperty);
            Assert.AreEqual(typeof(string), departmentProperty.PropertyType);
        }

        [Test]
        public void Test_Employee_Id_Property_DataType()
        {
            var idProperty = _employeeProperties.FirstOrDefault(prop => prop.Name == "Id");
            Assert.NotNull(idProperty);
            Assert.AreEqual(typeof(int), idProperty.PropertyType);
        }

        [Test]
        public void ApplicationDbContextContainsDbSetSlotProperty()
        {
            // using (var context = new ApplicationDbContext(_dbContextOptions))
            //         {
            // var context = new ApplicationDbContext();
        
            var propertyInfo = _context.GetType().GetProperty("Depts");
        
            Assert.IsNotNull(propertyInfo);
            Assert.AreEqual(typeof(DbSet<Dept>), propertyInfo.PropertyType);
                    // }
        }

        
    }
}

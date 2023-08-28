using NUnit.Framework;
using dotnetapp.Models; // Adjust the namespace to match your project
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace dotnetapp.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private EMSDbContext _context;
        private Type _deptType;
        private Type _employeeType;


        [SetUp]
        public void Setup()
        {
            _deptType = new Dept().GetType();
            _deptType = new Dept().GetType();

            // Set up the database context before running each test
            var options = new DbContextOptionsBuilder<EMSDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new EMSDbContext(options);
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
            Assert.NotNull(_deptType);
        }
    }
}

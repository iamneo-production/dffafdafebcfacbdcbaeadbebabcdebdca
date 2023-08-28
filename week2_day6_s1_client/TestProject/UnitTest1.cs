using NUnit.Framework;
using dotnetapp.Models; // Adjust the namespace to match your project

namespace dotnetapp.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        private EMSDbContext _context;

        [OneTimeSetUp]
        public void Setup()
        {
            // Set up the database context before running tests
            // Use an in-memory database or another suitable approach for testing
            // For brevity, let's assume you have a method to create the context
            _context = CreateDbContext();
        }

        [Test]
        public void CreateDept_AddsDeptToDatabase()
        {
            // Arrange
            var dept = new Dept { Id = 1, Name = "Sample Department", Location = "Sample Location" };

            // Act
            _context.Dept.Add(dept);
            _context.SaveChanges();

            // Assert
            var addedDept = _context.Dept.Find(1);
            Assert.IsNotNull(addedDept);
            Assert.AreEqual("Sample Department", addedDept.Name);
        }

    //     [Test]
    //     public void ReadEmployee_ReturnsEmployeeFromDatabase()
    //     {
    //         // Arrange
    //         var employeeId = 1; // Assume there's an employee with this ID in the database

    //         // Act
    //         var employee = _context.Employee.Find(employeeId);

    //         // Assert
    //         Assert.IsNotNull(employee);
    //         Assert.AreEqual(employeeId, employee.Id);
    //     }

    //     [Test]
    //     public void UpdateEmployee_UpdatesEmployeeInDatabase()
    //     {
    //         // Arrange
    //         var employeeId = 1; // Assume there's an employee with this ID in the database
    //         var updatedSalary = 50000;

    //         // Act
    //         var employee = _context.Employee.Find(employeeId);
    //         employee.Salary = updatedSalary;
    //         _context.SaveChanges();

    //         // Assert
    //         var updatedEmployee = _context.Employee.Find(employeeId);
    //         Assert.AreEqual(updatedSalary, updatedEmployee.Salary);
    //     }

    //     [Test]
    //     public void DeleteDept_RemovesDeptFromDatabase()
    //     {
    //         // Arrange
    //         var deptId = 1; // Assume there's a department with this ID in the database

    //         // Act
    //         var dept = _context.Dept.Find(deptId);
    //         _context.Dept.Remove(dept);
    //         _context.SaveChanges();

    //         // Assert
    //         var deletedDept = _context.Dept.Find(deptId);
    //         Assert.IsNull(deletedDept);
    //     }
    }
}

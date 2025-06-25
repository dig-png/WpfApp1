using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp1;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WpfApp1.Tests
{
    [TestClass]
    public class StudentTests
    {
        private ApplicationContext GetInMemoryDb()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseSqlite("Filename=:memory:")
                .Options;

            var context = new ApplicationContext(options);
            context.Database.OpenConnection();
            context.Database.EnsureCreated();
            return context;
        }

        [TestMethod]
        public void CanAddStudent()
        {
            using var db = GetInMemoryDb();

            var student = new Student
            {
                FirstName = "Тест",
                LastName = "Тестов",
                GroupName = "Тестовая группа"
            };

            db.Students.Add(student);
            db.SaveChanges();

            var saved = db.Students.FirstOrDefault(s => s.FirstName == "Тест");

            Assert.IsNotNull(saved);
            Assert.AreEqual("Тестов", saved.LastName);
        }
    }
}
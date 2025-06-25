using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp1;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WpfApp1.Tests
{
    [TestClass]
    public class AverageScoreTests
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
        public void CalculateAverageScore()
        {
            using var db = GetInMemoryDb();

            var student = new Student
            {
                FirstName = "Пётр",
                LastName = "Петров",
                GroupName = "Группа 2"
            };
            db.Students.Add(student);
            db.SaveChanges();

            db.Grades.AddRange(
                new Grade { SubjectName = "История", Score = 4, StudentId = student.StudentId },
                new Grade { SubjectName = "Биология", Score = 5, StudentId = student.StudentId },
                new Grade { SubjectName = "Математика", Score = 3, StudentId = student.StudentId }
            );
            db.SaveChanges();

            var avgScore = db.Grades.Where(g => g.StudentId == student.StudentId).Average(g => g.Score);

            Assert.AreEqual(4.0, avgScore, 0.01);
        }
    }
}

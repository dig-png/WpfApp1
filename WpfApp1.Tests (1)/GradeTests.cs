using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp1;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WpfApp1.Tests
{
    [TestClass]
    public class GradeTests
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
        public void CanAddGrade()
        {
            using var db = GetInMemoryDb();

            var student = new Student
            {
                FirstName = "Иван",
                LastName = "Иванов",
                GroupName = "Группа 1"
            };
            db.Students.Add(student);
            db.SaveChanges();

            var grade = new Grade
            {
                SubjectName = "Физика",
                Score = 5,
                StudentId = student.StudentId
            };
            db.Grades.Add(grade);
            db.SaveChanges();

            var saved = db.Grades.Include(g => g.Student).FirstOrDefault(g => g.SubjectName == "Физика");

            Assert.IsNotNull(saved);
            Assert.AreEqual(5, saved.Score);
            Assert.AreEqual(student.StudentId, saved.StudentId);
        }
    }
}

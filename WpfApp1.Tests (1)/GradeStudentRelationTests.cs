using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp1;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WpfApp1.Tests
{
    [TestClass]
    public class GradeStudentRelationTests
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
        public void GradeHasStudent()
        {
            using var db = GetInMemoryDb();

            var student = new Student
            {
                FirstName = "Марина",
                LastName = "Маринова",
                GroupName = "Группа 3"
            };
            db.Students.Add(student);
            db.SaveChanges();

            var grade = new Grade
            {
                SubjectName = "Химия",
                Score = 4,
                StudentId = student.StudentId
            };
            db.Grades.Add(grade);
            db.SaveChanges();

            var savedGrade = db.Grades.Include(g => g.Student).FirstOrDefault(g => g.GradeId == grade.GradeId);

            Assert.IsNotNull(savedGrade.Student);
            Assert.AreEqual("Марина", savedGrade.Student.FirstName);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp1;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WpfApp1.Tests
{
    [TestClass]
    public class SubjectTests
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
        public void CanAddSubject()
        {
            using var db = GetInMemoryDb();

            var subject = new Subject
            {
                Name = "Математика"
            };

            db.Subjects.Add(subject);
            db.SaveChanges();

            var saved = db.Subjects.FirstOrDefault(s => s.Name == "Математика");

            Assert.IsNotNull(saved);
        }
    }
}

using Microsoft.EntityFrameworkCore;

namespace WpfApp1
{
    public class ApplicationContext : DbContext
    {
        // Конструктор по умолчанию
        public ApplicationContext() : base()
        {
        }

        // Новый конструктор, принимающий параметры конфигурации
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Строка подключения по умолчанию (если не переданы options)
                optionsBuilder.UseSqlite("Data Source=students_extended.db");
            }
        }

        // Остальная конфигурация модели и прочее...
    }
}

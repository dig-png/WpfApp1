using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace WpfApp1
{
    public partial class GradesWindow : Window
    {
        public GradesWindow()
        {
            InitializeComponent();
            LoadGrades();
        }

        private void LoadGrades()
        {
            using (var db = new ApplicationContext())
            {
                var gradesList = db.Grades
                    .Include(g => g.Student)  // загружаем данные о студенте, если нужно
                    .ToList();                // ← без сортировки по дате

                GradesDataGrid.ItemsSource = gradesList;
            }
        }
    }
}

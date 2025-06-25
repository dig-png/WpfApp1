using System.Linq;
using System.Windows;

namespace WpfApp1
{
    public partial class StudentsWindow : Window
    {
        public StudentsWindow()
        {
            InitializeComponent();

            LoadStudents();
        }

        private void LoadStudents()
        {
            using (var db = new ApplicationContext())
            {
                // Загружаем студентов из базы
                var studentsList = db.Students.ToList();

                // Привязываем список к DataGrid
                StudentsDataGrid.ItemsSource = studentsList;
            }
        }
    }
}

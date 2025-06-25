using System.Linq;
using System.Windows;

namespace WpfApp1
{
    public partial class SubjectsWindow : Window
    {
        public SubjectsWindow()
        {
            InitializeComponent();
            LoadSubjects();
        }

        private void LoadSubjects()
        {
            using (var db = new ApplicationContext())
            {
                var subjectsList = db.Subjects.ToList();
                SubjectsDataGrid.ItemsSource = subjectsList;
            }
        }
    }
}

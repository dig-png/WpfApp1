using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnStudents_Click(object sender, RoutedEventArgs e)
        {
            var window = new StudentsWindow();
            window.ShowDialog();
        }

        private void BtnSubjects_Click(object sender, RoutedEventArgs e)
        {
            var window = new SubjectsWindow();
            window.ShowDialog();
        }

        private void BtnGrades_Click(object sender, RoutedEventArgs e)
        {
            var window = new GradesWindow();
            window.ShowDialog();
        }
    }
}

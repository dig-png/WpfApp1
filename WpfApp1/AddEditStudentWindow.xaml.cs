using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WpfApp1;

namespace StudentGradesWPF // Приведено в соответствие с XAML
{
    public partial class AddEditStudentWindow : Window
    {
        public Student Student { get; private set; } = new Student();

        public AddEditStudentWindow()
        {
            InitializeComponent(); // ОБЯЗАТЕЛЬНО для связывания XAML
            InitializePlaceholders();
        }

        private void InitializePlaceholders()
        {
            SetPlaceholder(TxtFirstName);
            SetPlaceholder(TxtLastName);
            SetPlaceholder(TxtGroup);
        }

        private void SetPlaceholder(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = (string)textBox.Tag;
                textBox.Foreground = Brushes.Gray;
            }

            textBox.GotFocus += (s, e) =>
            {
                if (textBox.Text == (string)textBox.Tag)
                {
                    textBox.Text = "";
                    textBox.Foreground = Brushes.Black;
                }
            };

            textBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = (string)textBox.Tag;
                    textBox.Foreground = Brushes.Gray;
                }
            };
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (TxtFirstName.Text == (string)TxtFirstName.Tag ||
                TxtLastName.Text == (string)TxtLastName.Tag ||
                TxtGroup.Text == (string)TxtGroup.Tag)
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            Student.FirstName = TxtFirstName.Text;
            Student.LastName = TxtLastName.Text;
            Student.GroupName = TxtGroup.Text;

            DialogResult = true;
            Close();
        }
    }
}

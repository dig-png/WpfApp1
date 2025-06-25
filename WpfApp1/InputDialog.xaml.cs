using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public partial class InputDialog : Window
    {
        public string Answer => InputBox.Text;
        public string Prompt { get; }

        public InputDialog(string prompt)
        {
            Prompt = prompt;
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
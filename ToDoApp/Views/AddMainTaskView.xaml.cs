using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDoApp.Views
{
    /// <summary>
    /// Logika interakcji dla klasy AddMainTaskView.xaml
    /// </summary>
    public partial class AddMainTaskView : UserControl
    {
        public AddMainTaskView()
        {
            InitializeComponent();
            DataContext = this;

        }

        public bool AreFieldsValid
        {
            get { return !string.IsNullOrEmpty(titleTextBox.Text) && !string.IsNullOrEmpty(descTextBox.Text); }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnAddTask.IsEnabled = AreFieldsValid;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}

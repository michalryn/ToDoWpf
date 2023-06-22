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
using ToDoApp.Models;

namespace ToDoApp.Views
{
    /// <summary>
    /// Logika interakcji dla klasy HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();

            FilterBy.ItemsSource = new string[] { "Title", "Priority"};

        }

        public Predicate<object> GetFilter()
        {
            switch (FilterBy.SelectedItem as string) 
            {
                case "Title":
                    return TitleFilter;

                case "Priority":
                    return PriorityFilter;

            }

            return TitleFilter;
        }

        private bool TitleFilter(object obj)
        {
            var Filterobj = obj as MainTask;

            return Filterobj.Title.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase);

        }

        private bool PriorityFilter(object obj)
        {
            var Filterobj = obj as MainTask;

            return Filterobj.PriorityLevel.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase);

        }


        private void FilterBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(FilterTextBox.Text == null)
            {
                TasksList.Items.Filter = null;
            }
            else
            {
                TasksList.Items.Filter = GetFilter();
            }
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TasksList.Items.Filter = GetFilter();
        }
    }
}

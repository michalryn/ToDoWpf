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

            FilterBy.ItemsSource = new string[] { "Title", "Priority Low", "Priority Medium", "Priority High", "Priority Undefined", "Completed", "Uncompleted"};
            FilterBy.SelectedIndex = 0;

        }

        public Predicate<object> GetFilter()
        {
            switch (FilterBy.SelectedItem as string) 
            {
                case "Title":
                    return TitleFilter;

                case "Priority Low":
                    return PriorityFilterLow;
                
                case "Priority Medium":
                    return PriorityFilterMedium;
                
                case "Priority High":
                    return PriorityFilterHigh;

                case "Priority Undefined":
                    return PriorityFilterUndefined;

                case "Completed":
                    return CompletedFilter;

                case "Uncompleted":
                    return UncompletedFilter;
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

        private bool CompletedFilter(object obj)
        {
            var Filterobj = obj as MainTask;

            return Filterobj.IsCompleted == true;
        }

        private bool UncompletedFilter(object obj)
        {
            var Filterobj = obj as MainTask;

            return Filterobj.IsCompleted == false;
        }

        private bool PriorityFilterLow(object obj)
        {
            var Filterobj = obj as MainTask;

            return Filterobj.PriorityLevel.Contains("Low", StringComparison.OrdinalIgnoreCase);
        }

        private bool PriorityFilterMedium(object obj)
        {
            var Filterobj = obj as MainTask;

            return Filterobj.PriorityLevel.Contains("Medium", StringComparison.OrdinalIgnoreCase);
        }

        private bool PriorityFilterHigh(object obj)
        {
            var Filterobj = obj as MainTask;

            return Filterobj.PriorityLevel.Contains("High", StringComparison.OrdinalIgnoreCase);
        }

        private bool PriorityFilterUndefined(object obj)
        {
            var Filterobj = obj as MainTask;

            return Filterobj.PriorityLevel.Contains("Undefined", StringComparison.OrdinalIgnoreCase);
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

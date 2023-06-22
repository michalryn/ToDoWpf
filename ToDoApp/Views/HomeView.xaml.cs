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
using ToDoApp.Common;
using ToDoApp.Models;

namespace ToDoApp.Views
{
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            FilterBy.ItemsSource = new string[] { "All", "Title", "Priority Low", "Priority Medium", "Priority High", "Priority Undefined", "Completed", "Uncompleted" };
        }

        public Predicate<object> GetFilter()
        {
            switch (FilterBy.SelectedItem as string)
            {
                case "All":
                    return null;

                case "Title":
                    return TitleFilter;

                case "Priority Low":
                case "Priority Medium":
                case "Priority High":
                case "Priority Undefined":
                    return PriorityFilter;

                case "Completed":
                    return CompletedFilter;

                case "Uncompleted":
                    return UncompletedFilter;

                default:
                    return null;
            }
        }

        private bool TitleFilter(object obj)
        {
            var filterObj = obj as MainTask;
            return filterObj.Title.Contains(FilterTextBox.Text, StringComparison.OrdinalIgnoreCase);
        }

        private bool PriorityFilter(object obj)
        {
            var filterObj = obj as MainTask;
            var selectedPriority = FilterBy.SelectedItem as string;
            var priorityEnum = (PriorityLevelEnum)Enum.Parse(typeof(PriorityLevelEnum), selectedPriority.ToUpper());
            return filterObj.PriorityLevel == priorityEnum;
        }

        private bool CompletedFilter(object obj)
        {
            var filterObj = obj as MainTask;
            return filterObj.IsCompleted;
        }

        private bool UncompletedFilter(object obj)
        {
            var filterObj = obj as MainTask;
            return !filterObj.IsCompleted;
        }

        private void FilterBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FilterTextBox.Text == null)
            {
                TasksList.Items.Filter = GetFilter();
            }
            else
            {
                TasksList.Items.Filter = CombineFilters(GetFilter(), TitleFilter);
            }
        }

        private void FilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TasksList.Items.Filter = CombineFilters(GetFilter(), TitleFilter);
        }

        private Predicate<object> CombineFilters(Predicate<object> filter1, Predicate<object> filter2)
        {
            if (filter1 == null && filter2 == null)
                return null;
            if (filter1 == null)
                return filter2;
            if (filter2 == null)
                return filter1;
            return o => filter1(o) && filter2(o);
        }
    }
}
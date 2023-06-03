using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core;
using ToDoApp.Services;

namespace ToDoApp.ViewModels
{
    public class HomeViewModel : ViewModel
    {
        private INavigationService _navigation;

        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertChanged();
            }
        }

        public RelayCommand NavigateToTaskViewCommand { get; set; }

        public HomeViewModel(INavigationService navigation)
        {
            Navigation = navigation;
            NavigateToTaskViewCommand = new RelayCommand(o => { Navigation.NavigateTo<TaskViewModel>(); }, o => true);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core;
using ToDoApp.Models;
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
                OnPropertyChanged();
            }
        }


        private FakeTaskRepo FakeTaskRepo = new FakeTaskRepo();
        public ObservableCollection<MainTask> Tasks { get; set; }

        public RelayCommand NavigateToAddMainTaskViewCommand { get; set; }

        public HomeViewModel(INavigationService navigation)
        {
            Tasks = FakeTaskRepo.GetTasks();
            Navigation = navigation;
            NavigateToAddMainTaskViewCommand = new RelayCommand(o => { Navigation.NavigateTo<AddMainTaskViewModel>(); }, o => true);
        }
    }
}

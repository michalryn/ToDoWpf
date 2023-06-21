using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core;
using ToDoApp.Data.IRepositories;
using ToDoApp.Models;
using ToDoApp.Services;

namespace ToDoApp.ViewModels
{
    public class HomeViewModel : ViewModel
    {
        private readonly IMainTaskService _mainTaskService;
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
        private ObservableCollection<MainTask> _tasks;
        public ObservableCollection<MainTask> Tasks
        {
            get { return _tasks; }
            set
            {
                _tasks = value;
                OnPropertyChanged(nameof(Tasks));
            }
        }

        private MainTask _selectedTask;
        public MainTask SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                _selectedTask = value;
                OnPropertyChanged(nameof(SelectedTask));
            }
        }

        public RelayCommand NavigateToAddMainTaskViewCommand { get; set; }
        public RelayCommand LoadTasksCommand { get; set; }
        public RelayCommand DeleteTaskCommand { get; set; }

        public HomeViewModel(INavigationService navigation, IMainTaskService mainTaskService)
        {
            _mainTaskService = mainTaskService;
            Navigation = navigation;
            NavigateToAddMainTaskViewCommand = new RelayCommand(o => { Navigation.NavigateTo<AddMainTaskViewModel>(); });
            LoadTasksCommand = new RelayCommand(o => { LoadTasks(); });
            DeleteTaskCommand = new RelayCommand(o => DeleteTask(), o => CanDelete());
        }

        public async void DeleteTask()
        {
            await _mainTaskService.RemoveMainTaskAsync(SelectedTask.Id);
            Tasks.Remove(SelectedTask);
        }

        public bool CanDelete()
        {
            if(_selectedTask is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async void LoadTasks()
        {
            Tasks = await _mainTaskService.GetAllMainTasksAsync();
        }
    }
}

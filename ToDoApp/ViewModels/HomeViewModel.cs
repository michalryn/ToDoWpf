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
        private readonly IMainTaskRepository _mainTaskRepository;
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

        public RelayCommand NavigateToAddMainTaskViewCommand { get; set; }
        public RelayCommand LoadTasksCommand { get; set; }

        public HomeViewModel(INavigationService navigation, IMainTaskRepository mainTaskRepository)
        {
            _mainTaskRepository = mainTaskRepository;
            Navigation = navigation;
            NavigateToAddMainTaskViewCommand = new RelayCommand(o => { Navigation.NavigateTo<AddMainTaskViewModel>(); });
            LoadTasksCommand = new RelayCommand(o => { LoadTasks(); });
        }

        public async void LoadTasks()
        {
            var tasks = await _mainTaskRepository.GetAllAsync();

            Tasks = new ObservableCollection<MainTask>(tasks.Select(t => new MainTask()
            {
                Id = t.Id,
                Title = t.Title,
                PriorityLevel = t.PriorityLevel,
                CreationDate = t.CreationDate,
                DeadlineDate = t.DeadlineDate,
                Description = t.Description,
                Progress = t.Progress,
                IsCompleted = t.IsCompleted
            }));
        }
    }
}

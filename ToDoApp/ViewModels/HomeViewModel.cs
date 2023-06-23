using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using ToDoApp.Core;
using ToDoApp.Data.IRepositories;
using ToDoApp.Models;
using ToDoApp.Services;
using ToDoApp.Stores;

namespace ToDoApp.ViewModels
{
    public class HomeViewModel : ViewModel
    {
        private readonly IMainTaskService _mainTaskService;
        private readonly SelectedTaskStore _selectedTaskStore;
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
        public RelayCommand ViewTaskDetailsCommand { get; set; }

        public HomeViewModel(INavigationService navigation, IMainTaskService mainTaskService, SelectedTaskStore selectedTaskStore)
        {
            _mainTaskService = mainTaskService;
            _selectedTaskStore = selectedTaskStore;
            Navigation = navigation;
            NavigateToAddMainTaskViewCommand = new RelayCommand(o => { Navigation.NavigateTo<AddMainTaskViewModel>(); });
            LoadTasksCommand = new RelayCommand(o => { LoadTasks(); });
            DeleteTaskCommand = new RelayCommand(o => DeleteTask(), o => IsSelected());
            ViewTaskDetailsCommand = new RelayCommand(o => ViewTaskDetails(), o => IsSelected());
            Tasks = new ObservableCollection<MainTask>();
            Tasks.CollectionChanged += Tasks_CollectionChanged;
        }

        private void Tasks_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if(e.NewItems is not null)
                foreach(MainTask item in e.NewItems)
                    item.PropertyChanged += Item_PropertyChanged;

            if(e.OldItems is not null)
                foreach(MainTask item in e.OldItems)
                    item.PropertyChanged -= Item_PropertyChanged;
        }

        private async void Item_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsCompleted")
            {
                var task = sender as MainTask;
                
                if (task is null)
                    return;

                await SaveTask(task);
            }
        }

        public void ViewTaskDetails()
        {
            SelectedTask.PropertyChanged -= Item_PropertyChanged;
            _selectedTaskStore.MainTask = SelectedTask ?? null;
            Navigation.NavigateTo<TaskDetailsViewModel>();
        }

        public async void DeleteTask()
        {
            await _mainTaskService.RemoveMainTaskAsync(SelectedTask.Id);
            Tasks.Remove(SelectedTask);
        }

        public bool IsSelected()
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
            var tasks = await _mainTaskService.GetAllMainTasksAsync();
            foreach (var task in tasks)
            {
                Tasks.Add(task);
            }
        }
        public void UnloadTasks()
        {
            Tasks.Clear();
        }
        public async Task SaveTask(MainTask task)
        {
            await _mainTaskService.UpdateMainTaskAsync(task);
        }
    }
}

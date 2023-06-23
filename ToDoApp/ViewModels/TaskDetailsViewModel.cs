using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core;
using ToDoApp.Models;
using ToDoApp.Services;
using ToDoApp.Stores;

namespace ToDoApp.ViewModels
{
    public class TaskDetailsViewModel : ViewModel
    {
        private readonly IMainTaskService _mainTaskService;
        private readonly ISubTaskService _subTaskService;
        private readonly SelectedTaskStore _selectedTaskStore;
        private readonly INavigationService _navigation;

        private MainTask _mainTask;
        public MainTask MainTask
        {
            get { return _mainTask; }
            set
            {
                _mainTask = value;
                OnPropertyChanged(nameof(MainTask));
            }
        }

        private string _selectedPriority;
        public string SelectedPriority
        {
            get { return _selectedPriority; }
            set
            {
                _selectedPriority = value;
                OnPropertyChanged(nameof(SelectedPriority));
            }
        }

        private List<string> _priorityComboBoxItems;
        public List<string> PriorityComboBoxItems
        {
            get { return _priorityComboBoxItems; }
            set
            {
                _priorityComboBoxItems = value;
                OnPropertyChanged(nameof(PriorityComboBoxItems));
            }
        }

        private string _subTaskTitle;
        public string SubTaskTitle
        {
            get { return _subTaskTitle; }
            set
            {
                _subTaskTitle = value;
                OnPropertyChanged(nameof(SubTaskTitle));
            }
        }

        private ObservableCollection<SubTask> _subTasks;
        public ObservableCollection<SubTask> SubTasks
        {
            get { return _subTasks; }
            set
            {
                _subTasks = value;
                OnPropertyChanged(nameof(SubTasks));
            }
        }

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand AddSubTaskCommand { get; set; }
        public RelayCommand RemoveSubTaskCommand { get; set; }

        public TaskDetailsViewModel(IMainTaskService mainTaskService, ISubTaskService subTaskService, SelectedTaskStore selectedTaskStore, INavigationService navigation)
        {
            _mainTaskService = mainTaskService;
            _subTaskService = subTaskService;
            _selectedTaskStore = selectedTaskStore;
            _navigation = navigation;
            PriorityComboBoxItems = _mainTaskService.GetPriorityLevels();
            SaveCommand = new RelayCommand(o => Save());
            AddSubTaskCommand = new RelayCommand(o => AddSubTask(), o => CanAddSubTask());
            RemoveSubTaskCommand = new RelayCommand(subTask => RemoveSubTask(subTask));
            SubTasks = new ObservableCollection<SubTask>();
            SubTasks.CollectionChanged += SubTasks_CollectionChanged;
        }

        private void SubTasks_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems is not null)
                foreach (SubTask item in e.NewItems)
                    item.PropertyChanged += SubTask_PropertyChanged;
            if(e.OldItems is not null)
                foreach(SubTask item in e.OldItems)
                    item.PropertyChanged -= SubTask_PropertyChanged;
        }

        private async void SubTask_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(SubTask.IsCompleted))
            {
                var subTask = sender as SubTask;
                if (subTask is null)
                    return;
                await SaveSubTask(subTask);
            }
        }

        public void LoadDetails()
        {
            MainTask = _selectedTaskStore.MainTask ?? new MainTask();
            SelectedPriority = MainTask.PriorityLevel;
            LoadSubTasks();
        }

        public void LoadSubTasks()
        {
            SubTasks.Clear();
            var subTasks = _selectedTaskStore.MainTask?.SubTasks;
            if (subTasks is null)
                subTasks = new List<SubTask>();
            foreach (var subTask in subTasks)
            {
                SubTasks.Add(subTask);
            }
        }

        public async void Save()
        {
            MainTask.PriorityLevel = SelectedPriority;
            await _mainTaskService.UpdateMainTaskAsync(MainTask);
            MainTask = null;
            _navigation.NavigateTo<HomeViewModel>();
        }

        public async Task SaveSubTask(SubTask subTask)
        {
            await _subTaskService.UpdateSubTaskAsync(subTask);
        }

        public async void AddSubTask()
        {
            SubTask subTask = new SubTask()
            {
                Title = _subTaskTitle,
                MainTaskId = MainTask.Id
            };
            await _subTaskService.AddSubTaskAsync(subTask);
            _selectedTaskStore.MainTask = await _mainTaskService.GetMainTaskByIdAsync(MainTask.Id);
            SubTaskTitle = "";
            LoadSubTasks();
        }

        public bool CanAddSubTask()
        {
            if(SubTaskTitle.IsNullOrEmpty())
            {
                return false;
            }
            else
                return true;
        }

        public async void RemoveSubTask(object sender)
        {
            SubTask subTask = sender as SubTask;

            if(subTask is null) 
                return;

            await _subTaskService.DeleteSubTaskAsync(subTask.Id);
            SubTasks.Remove(subTask);
        }
    }
}

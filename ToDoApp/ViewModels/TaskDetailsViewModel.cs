using System;
using System.Collections.Generic;
using System.Linq;
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

        public TaskDetailsViewModel(IMainTaskService mainTaskService, ISubTaskService subTaskService, SelectedTaskStore selectedTaskStore, INavigationService navigation)
        {
            _mainTaskService = mainTaskService;
            _subTaskService = subTaskService;
            _selectedTaskStore = selectedTaskStore;
            _navigation = navigation;
        }

        public void LoadDetails()
        {
            MainTask = _selectedTaskStore.MainTask ?? new MainTask();
        }
    }
}

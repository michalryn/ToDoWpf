using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core;
using ToDoApp.Data.DTOs;
using ToDoApp.Data.IRepositories;
using ToDoApp.Models;
using ToDoApp.Services;

namespace ToDoApp.ViewModels
{
    public class AddMainTaskViewModel : ViewModel
    {
        private readonly IMainTaskService _mainTaskService;

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string _priorityLevel;

        public string PriorityLevel
        {
            get { return _priorityLevel; }
            set
            {
                _priorityLevel = value;
                OnPropertyChanged(nameof(PriorityLevel));
            }
        }

        private DateTime _startDate = DateTime.Today;

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        private DateTime _deadlineDate = DateTime.Today;

        public DateTime DeadlineDate
        {
            get { return _deadlineDate; }
            set
            {
                _deadlineDate = value;
                OnPropertyChanged(nameof(DeadlineDate));
            }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private bool _isButtonEnabled;
        public bool IsButtonEnabled
        {
            get { return _isButtonEnabled; }
            set
            {
                _isButtonEnabled = value;
                OnPropertyChanged(nameof(IsButtonEnabled));
            }
        }

        public bool CanExecute()
        {
            if (!string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(PriorityLevel) && !string.IsNullOrEmpty(Description))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public RelayCommand AddMainTaskCommand { get; set; }

        public AddMainTaskViewModel(IMainTaskService mainTaskService)
        {
            _mainTaskService = mainTaskService;
            AddMainTaskCommand = new RelayCommand(o => AddMainTask(), o => CanExecute());
        }


        public async void AddMainTask()
        {
            MainTask task = new MainTask()
            {
                Title = this.Title,
                PriorityLevel = this.PriorityLevel,
                CreationDate = this.StartDate,
                DeadlineDate = this.DeadlineDate,
                Description = this.Description,
                Progress = 0,
                IsCompleted = false
            };

            await _mainTaskService.AddMainTaskAsync(task);
        }
    }
}

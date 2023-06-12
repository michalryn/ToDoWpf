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
        private readonly IMainTaskRepository _mainTaskRepository;

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
                UpdateButtonState();
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
                UpdateButtonState();
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
                UpdateButtonState();
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

        private void UpdateButtonState()
        {
            if (!string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(PriorityLevel) && !string.IsNullOrEmpty(Description))
            {
                IsButtonEnabled = true;
            }
            else
            {
                IsButtonEnabled = false;
            }
        }

        public bool AreFieldsValid
        {
            get
            {
                return !string.IsNullOrEmpty(Title) &&
                       !string.IsNullOrEmpty(Description) &&
                       !string.IsNullOrEmpty(PriorityLevel);
            }
        }

        public RelayCommand AddMainTaskCommand { get; set; }

        public AddMainTaskViewModel(IMainTaskRepository mainTaskRepository)
        {
            _mainTaskRepository = mainTaskRepository;
            AddMainTaskCommand = new RelayCommand(o => AddMainTask());
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

            MainTaskDTO newTask = new MainTaskDTO()
            {
                Title = task.Title,
                PriorityLevel = task.PriorityLevel,
                CreationDate = task.CreationDate,
                DeadlineDate = task.DeadlineDate,
                Description = task.Description,
                Progress = task.Progress,
                IsCompleted = task.IsCompleted
            };

            await _mainTaskRepository.AddMainTaskAsync(newTask);
        }
    }
}

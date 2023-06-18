using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core;
using ToDoApp.Data.DTOs;
using ToDoApp.Models;
using ToDoApp.Services;

namespace ToDoApp.ViewModels
{
    public class AddSubTaskViewModel : ViewModel
    {
        private readonly ISubTaskService _subTaskService;
        private int _mainTaskId;
        private string _title;
        private string? _description;
        private bool _isCompleted;

        public int MainTaskId
        {
            get { return _mainTaskId; }
            set
            {
                _mainTaskId = value;
                OnPropertyChanged(nameof(MainTaskId));
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        public string? Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public bool IsCompleted
        {
            get { return _isCompleted; }
            set
            {
                _isCompleted = value;
                OnPropertyChanged(nameof(IsCompleted));
            }
        }

        public RelayCommand AddSubTaskCommand { get; set; }

        public AddSubTaskViewModel(ISubTaskService subTaskService)
        {
            _subTaskService = subTaskService;
            AddSubTaskCommand = new RelayCommand(o => AddSubTask());
        }

        public async void AddSubTask()
        {
            SubTask subTask = new SubTask()
            {
                MainTaskId = this.MainTaskId,
                Title = this.Title,
                Description = this.Description,
                IsCompleted = this.IsCompleted
            };

            await _subTaskService.AddSubTaskAsync(subTask);
        }
    }

}

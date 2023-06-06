using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core;
using ToDoApp.Models;
using ToDoApp.Services;

namespace ToDoApp.ViewModels
{
    public class AddMainTaskViewModel : ViewModel
    {
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

        private DateTime _startDate;

        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        private DateTime _deadlineDate;

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


        public FakeTaskRepo repo { get; set; } = new FakeTaskRepo();
        public RelayCommand AddMainTaskCommand { get; set; }

        public AddMainTaskViewModel()
        {
            AddMainTaskCommand = new RelayCommand(o => AddMainTask(), o => true);
        }


        public void AddMainTask()
        {
            MainTask task = new MainTask()
            {
                Id = 1,
                Title = this.Title,
                PriorityLevel = this.PriorityLevel,
                CreationDate = this.StartDate,
                DeadlineDate = this.DeadlineDate,
                Description = this.Description,
                Progress = 0,
                IsCompleted = false
            };

            repo.AddTask(task);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core;

namespace ToDoApp.Models
{
    public class MainTask : ObservableObject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PriorityLevel { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DeadlineDate { get; set; }
        public string? Description { get; set; }
        public double? Progress { get; set; }
        public virtual ICollection<SubTask>? SubTasks { get; set; }
        private bool _isCompleted;
        public bool IsCompleted
        {
            get { return _isCompleted; }
            set
            {
                _isCompleted = value;
                OnPropertyChanged(nameof(IsCompleted));
                
            }
        }
    }
}

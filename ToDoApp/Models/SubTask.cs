using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core;
using ToDoApp.Data.DTOs;

namespace ToDoApp.Models
{
    public class SubTask : ObservableObject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
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
        public int MainTaskId { get; set; }
        public virtual MainTask MainTask { get; set; }
    }
}

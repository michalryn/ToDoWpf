using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Data.DTOs;

namespace ToDoApp.Models
{
    public class SubTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public int MainTaskId { get; set; }
        public virtual MainTaskDTO MainTask { get; set; }
    }
}

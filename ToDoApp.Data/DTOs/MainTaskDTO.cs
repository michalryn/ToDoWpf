using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Data.DTOs
{
    [Table("MainTask")]
    public class MainTaskDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string PriorityLevel { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        public DateTime? DeadlineDate { get; set; }
        public string? Description { get; set; }
        public double? Progress { get; set; }
        public virtual ICollection<SubTaskDTO>? SubTasks { get; set; }
        public bool IsCompleted { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Data.DTOs
{
    [Table("SubTask")]
    public class SubTaskDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        [Required]
        public int MainTaskId { get; set; }
        [ForeignKey("MainTaskId")]
        public virtual MainTaskDTO MainTask { get; set; }
    }
}

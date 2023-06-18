using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Data.DTOs;

namespace ToDoApp.Data.IRepositories
{
    public interface ISubTaskRepository
    {
        Task AddSubTaskAsync(SubTaskDTO subTask);
        Task DeleteSubTaskByIdAsync(int subTaskId);
        Task UpdateSubTaskAsync(SubTaskDTO subTask);
    }
}

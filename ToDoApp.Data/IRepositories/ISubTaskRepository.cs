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
        Task AddSubTaskAsync(MainTaskDTO mainTask);
        Task DeleteSubTaskByIdAsync(int id);
        Task UpdateSubTaskAsync(MainTaskDTO mainTask);
    }
}

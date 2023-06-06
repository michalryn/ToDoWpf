using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Data.DTOs;

namespace ToDoApp.Data.IRepositories
{
    public interface IMainTaskRepository
    {
        Task<IEnumerable<MainTaskDTO>> GetAllAsync();
        Task AddMainTaskAsync(MainTaskDTO mainTask);
        Task<MainTaskDTO> GetMainTaskByIdAsync(int id);
        Task DeleteMainTaskByIdAsync(int id);
        Task UpdateMainTaskAsync(MainTaskDTO mainTask);

    }
}

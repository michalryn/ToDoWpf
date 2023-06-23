using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Data.DTOs;
using ToDoApp.Data.IRepositories;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public interface ISubTaskService
    {
        Task AddSubTaskAsync(SubTask subTask);
        Task DeleteSubTaskAsync(int subTaskId);
        Task UpdateSubTaskAsync(SubTask subTask);
    }
    public class SubTaskService : ISubTaskService
    {
        private readonly ISubTaskRepository _subTaskRepository;

        public SubTaskService(ISubTaskRepository subTaskRepository)
        {
            _subTaskRepository = subTaskRepository;
        }

        public async Task AddSubTaskAsync(SubTask subTask)
        {
            SubTaskDTO newTask = new SubTaskDTO()
            {
                Title = subTask.Title,
                Description = subTask.Description,
                IsCompleted = subTask.IsCompleted,
                MainTaskId = subTask.MainTaskId,
            };
            await _subTaskRepository.AddSubTaskAsync(newTask);
        }

        public async Task DeleteSubTaskAsync(int subTaskId)
        {
            await _subTaskRepository.DeleteSubTaskByIdAsync(subTaskId);
        }

        public async Task UpdateSubTaskAsync(SubTask subTask)
        {
            try
            {
                var oldSubTask = await _subTaskRepository.GetByIdAsync(subTask.Id);
                if (oldSubTask is null)
                    return;

                oldSubTask.Title = subTask.Title;
                oldSubTask.IsCompleted = subTask.IsCompleted;

                await _subTaskRepository.UpdateSubTaskAsync(oldSubTask);
                return;
            }
            catch(Exception ex)
            {
                return;
            }
        }
    }
}

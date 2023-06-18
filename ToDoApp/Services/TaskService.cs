using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core;
using ToDoApp.Data.DTOs;
using ToDoApp.Data.IRepositories;
using ToDoApp.Models;
using ToDoApp.Views;

namespace ToDoApp.Services
{
    public interface IMainTaskService
    {
        Task<IEnumerable<MainTaskDTO>> GetAllMainTasksAsync();
        Task<MainTaskDTO> GetMainTaskByIdAsync(int taskId);
        Task AddMainTaskAsync(MainTask mainTask);
        Task RemoveMainTaskAsync(int taskId);
        Task UpdateMainTaskAsync(MainTask mainTask);

    }
    public class MainTaskService : IMainTaskService
    {
        private readonly IMainTaskRepository _mainTaskRepository;

        public MainTaskService(IMainTaskRepository mainTaskRepository)
        {
            _mainTaskRepository = mainTaskRepository;
        }

        public async Task<IEnumerable<MainTaskDTO>> GetAllMainTasksAsync()
        {
            return await _mainTaskRepository.GetAllAsync();
        }

        public async Task<MainTaskDTO> GetMainTaskByIdAsync(int taskId)
        {
            return await _mainTaskRepository.GetMainTaskByIdAsync(taskId);
        }

        public async Task AddMainTaskAsync(MainTask mainTask)
        {
            MainTaskDTO newTask = new MainTaskDTO()
            {
                Title = mainTask.Title,
                PriorityLevel = mainTask.PriorityLevel,
                CreationDate = mainTask.CreationDate,
                DeadlineDate = mainTask.DeadlineDate,
                Description = mainTask.Description,
                Progress = 0,
                IsCompleted = false
            };

            await _mainTaskRepository.AddMainTaskAsync(newTask);
        }

        public async Task RemoveMainTaskAsync(int taskId)
        {
            await _mainTaskRepository.DeleteMainTaskByIdAsync(taskId);
        }

        public async Task UpdateMainTaskAsync(MainTask mainTask)
        {
            MainTaskDTO newTask = new MainTaskDTO()
            {
                Title = mainTask.Title,
                PriorityLevel = mainTask.PriorityLevel,
                CreationDate = mainTask.CreationDate,
                DeadlineDate = mainTask.DeadlineDate,
                Description = mainTask.Description,
                Progress = mainTask.Progress,
                IsCompleted = mainTask.IsCompleted
            };
            await _mainTaskRepository.UpdateMainTaskAsync(newTask);
        }


    }

}

using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Common;
using ToDoApp.Core;
using ToDoApp.Data.DTOs;
using ToDoApp.Data.IRepositories;
using ToDoApp.Models;
using ToDoApp.Views;

namespace ToDoApp.Services
{
    public interface IMainTaskService
    {
        Task<ObservableCollection<MainTask>> GetAllMainTasksAsync();
        Task<MainTask> GetMainTaskByIdAsync(int taskId);
        Task AddMainTaskAsync(MainTask mainTask);
        Task RemoveMainTaskAsync(int taskId);
        Task UpdateMainTaskAsync(MainTask mainTask);

        List<string> GetPriorityLevels();

    }
    public class MainTaskService : IMainTaskService
    {
        private readonly IMainTaskRepository _mainTaskRepository;

        public MainTaskService(IMainTaskRepository mainTaskRepository)
        {
            _mainTaskRepository = mainTaskRepository;
        }

        public async Task<ObservableCollection<MainTask>> GetAllMainTasksAsync()
        {
            var tasks = await _mainTaskRepository.GetAllAsync();

            var observableTasks = new ObservableCollection<MainTask>(tasks.Select(t => new MainTask()
            {
                Id = t.Id,
                Title = t.Title,
                PriorityLevel = t.PriorityLevel,
                CreationDate = t.CreationDate,
                DeadlineDate = t.DeadlineDate,
                Description = t.Description,
                Progress = t.Progress,
                IsCompleted = t.IsCompleted,
                SubTasks = t.SubTasks?.Select(st => new SubTask()
                {
                    Id = st.Id,
                    Title = st.Title,
                    IsCompleted = st.IsCompleted,
                    MainTaskId = st.MainTaskId
                }).ToList()
            }));

            return observableTasks;
        }

        public async Task<MainTask> GetMainTaskByIdAsync(int taskId)
        {
            try
            {
                var dto = await _mainTaskRepository.GetMainTaskByIdAsync(taskId);
                if (dto is null)
                    return null;

                MainTask task = new MainTask()
                {
                    Id = dto.Id,
                    Title = dto.Title,
                    PriorityLevel = dto.PriorityLevel,
                    CreationDate = dto.CreationDate,
                    DeadlineDate = dto.DeadlineDate,
                    Description = dto.Description,
                    Progress = dto.Progress,
                    IsCompleted = dto.IsCompleted,
                    SubTasks = dto.SubTasks?.Select(st => new SubTask()
                    {
                        Id = st.Id,
                        Title = st.Title,
                        Description = st.Description,
                        MainTaskId = st.MainTaskId
                    }).ToList()
                };

                return task;
            }
            catch (Exception ex)
            {
                return null;
            }
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
            try
            {
                MainTaskDTO oldTask = await _mainTaskRepository.GetMainTaskByIdAsync(mainTask.Id);
                
                if (oldTask is null)
                    return;

                oldTask.Title = mainTask.Title;
                oldTask.PriorityLevel = mainTask.PriorityLevel;
                oldTask.CreationDate = mainTask.CreationDate;
                oldTask.DeadlineDate = mainTask.DeadlineDate;
                oldTask.Description = mainTask.Description;
                oldTask.Progress = mainTask.Progress;
                oldTask.IsCompleted = mainTask.IsCompleted;

                await _mainTaskRepository.UpdateMainTaskAsync(oldTask);

            }
            catch (Exception ex)
            {
                return;
            }
        }

        public List<string> GetPriorityLevels()
        {
            try
            {
                Type type;
                FieldInfo fieldInfo;
                DescriptionAttribute[] descriptionAttributes;
                List<string> priorities = new List<string>();

                var enumValues = Enum.GetValues(typeof(PriorityLevelEnum));

                foreach (var enumValue in enumValues)
                {
                    type = enumValue.GetType();
                    fieldInfo = type.GetField(enumValue.ToString());
                    descriptionAttributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

                    priorities.Add(descriptionAttributes[0].Description);
                }

                return priorities;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}

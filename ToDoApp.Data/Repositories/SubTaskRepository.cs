using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Data.DTOs;
using ToDoApp.Data.IRepositories;

namespace ToDoApp.Data.Repositories
{
    public class SubTaskRepository : ISubTaskRepository
    {
        private readonly DataContext _context;

        public SubTaskRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddSubTaskAsync(SubTaskDTO subTask)
        {
            var mainTask = await _context.MainTasks.Include(mt => mt.SubTasks).SingleOrDefaultAsync(mt => mt.Id == subTask.MainTaskId);

            if (mainTask != null)
            {
                mainTask.SubTasks.Add(subTask);
                await _context.UpdateEntityAndSaveChangesAsync(mainTask);
            }

        }

        public async Task DeleteSubTaskByIdAsync(int subTaskId)
        {
            var subTask = await _context.SubTasks.SingleOrDefaultAsync(st => st.Id == subTaskId);

            if (subTask != null)
            {
                _context.SubTasks.Remove(subTask);
                await _context.UpdateEntityAndSaveChangesAsync(subTask);
            }

        }

        public async Task UpdateSubTaskAsync(SubTaskDTO subTask)
        {
            var mainTask = await _context.MainTasks.Include(mt => mt.SubTasks).SingleOrDefaultAsync(mt => mt.Id == subTask.MainTaskId);
            if (mainTask != null)
            {
                var existingSubTask = mainTask.SubTasks.SingleOrDefault(st => st.Id == subTask.Id);
                if (existingSubTask != null)
                {
                    existingSubTask.Title = subTask.Title;
                    existingSubTask.Description = subTask.Description;
                    existingSubTask.IsCompleted = subTask.IsCompleted;

                    await _context.UpdateEntityAndSaveChangesAsync(mainTask);
                }
            }
        }

    }
}

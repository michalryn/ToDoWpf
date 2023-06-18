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
    public class MainTaskRepository : IMainTaskRepository
    {
        private readonly DataContext _context;

        public MainTaskRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MainTaskDTO>> GetAllAsync()
        {
            return await _context.MainTasks.Include(mt => mt.SubTasks).ToListAsync();
        }

        public async Task AddMainTaskAsync(MainTaskDTO mainTask)
        {
            _context.MainTasks.Add(mainTask);
            await _context.SaveChangesAsync();
        }

        public async Task<MainTaskDTO> GetMainTaskByIdAsync(int id)
        {
            var result = await _context.MainTasks.Include(mt => mt.SubTasks).Where(mt => mt.Id == id).FirstOrDefaultAsync();

            return result;
        }

        public async Task DeleteMainTaskByIdAsync(int id)
        {
            var mainTask = await _context.MainTasks.Include(mt => mt.SubTasks).Where(mt => mt.Id == id).FirstOrDefaultAsync();
            if (mainTask != null)
            {
                _context.MainTasks.Remove(mainTask);
                await _context.UpdateEntityAndSaveChangesAsync(mainTask);
            }
        }

        public async Task UpdateMainTaskAsync(MainTaskDTO mainTask)
        {
            await _context.UpdateEntityAndSaveChangesAsync(mainTask);
        }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        
    }
}

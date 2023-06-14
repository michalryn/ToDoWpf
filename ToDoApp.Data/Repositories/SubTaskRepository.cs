using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Data.IRepositories;

namespace ToDoApp.Data.Repositories
{
    public class SubTaskRepository 
    {
        private readonly DataContext _context;

        public SubTaskRepository(DataContext context)
        {
            _context = context;
        }


    }
}

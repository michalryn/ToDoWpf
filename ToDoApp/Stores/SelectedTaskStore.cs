using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Stores
{
    public class SelectedTaskStore
    {
        private MainTask? _mainTask;
        public MainTask? MainTask
        {
            get
            {
                return _mainTask;
            }
            set
            {
                _mainTask = value;
            }
        }
    }
}

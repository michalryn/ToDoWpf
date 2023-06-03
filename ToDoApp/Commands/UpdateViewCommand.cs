using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoApp.Models;

namespace ToDoApp.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "Home")
            {
                viewModel.SelectedViewModel = new HomeViewModel();
            }
            else if (parameter.ToString() == "AddTask")
            {
                viewModel.SelectedViewModel = new AddTaskViewModel();
            }
        }
    }
}
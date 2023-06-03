using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToDoApp.Commands;

namespace ToDoApp.Models
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand UpdateViewCommand { get; set; }

        public MainViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
        }
    }
}
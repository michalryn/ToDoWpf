using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core;
using ToDoApp.Services;

namespace ToDoApp.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private INavigationService _navigationService;
        public INavigationService Navigation
        {
            get => _navigationService;
            set
            {
                _navigationService = value;
                OnPropertChanged();
            }
        }

        public RelayCommand NavigateToHomeCommand { get; set; }
        public RelayCommand NavigateToTaskCommand { get; set; }

        public MainViewModel(INavigationService navService)
        {
            Navigation = navService;
            Navigation.NavigateTo<HomeViewModel>();
            NavigateToHomeCommand = new RelayCommand(o => { Navigation.NavigateTo<HomeViewModel>(); }, o => true);
            NavigateToTaskCommand = new RelayCommand(o => { Navigation.NavigateTo<TaskViewModel>(); }, o => true);
        }
    }
}

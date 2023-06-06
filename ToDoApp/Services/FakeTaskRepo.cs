using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public class FakeTaskRepo
    {
        public List<MainTask> MainTasks { get; set; } = new List<MainTask>()
        {
            new MainTask()
            {
                Id = 1,
                Title = "Posprzątać łazienkę",
                PriorityLevel = "Pilne",
                CreationDate = DateTime.Today,
                IsCompleted = false
            },
            new MainTask()
            {
                Id = 2,
                Title = "Zrobić zakupy",
                PriorityLevel = "Normalne",
                CreationDate = DateTime.Today,
                IsCompleted = false
            }
        };

        public ObservableCollection<MainTask> GetTasks()
        {
            ObservableCollection<MainTask> tasks = new ObservableCollection<MainTask>(MainTasks);
            return tasks;
        }

        public void AddTask(MainTask task)
        {
            MainTasks.Add(task);
        }
    }
}

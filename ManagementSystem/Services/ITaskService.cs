using ManagementSystem.Models;
using System.Collections.ObjectModel;

namespace ManagementSystem.Services
{
    public interface ITaskService
    {
        Task AddTaskAsync(TaskEntity taskEntity);
        Task<ObservableCollection<TaskEntity>> GetAllTasksAsync();
    }
}

using ManagementSystem.Models;

namespace ManagementSystem.Services
{
    public interface ITaskService
    {
        Task AddTaskAsync(TaskEntity taskEntity);
        Task<IEnumerable<TaskEntity>> GetAllTasksAsync();
        Task<TaskEntity> GetTaskWithCommentsAsync(Guid taskId);
    }
}

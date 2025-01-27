using ManagementSystem.Data;
using ManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementSystem.Services
{
    public class TaskService : ITaskService
    {
        public AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddTaskAsync(TaskEntity taskEntity)
        {
           await _context.Tasks.AddAsync(taskEntity);
           await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TaskEntity>> GetAllTasksAsync()
        {
            var taskList = await _context.Tasks.ToListAsync();
            return taskList;
        }
    }
}

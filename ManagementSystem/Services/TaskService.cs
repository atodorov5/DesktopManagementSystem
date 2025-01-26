using ManagementSystem.Data;
using ManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

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

        public async Task<ObservableCollection<TaskEntity>> GetAllTasksAsync()
        {
            var taskList = await _context.Tasks.ToListAsync();
            return new ObservableCollection<TaskEntity>(taskList);
        }
    }
}

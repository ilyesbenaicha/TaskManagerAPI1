using TaskManagerAPI1.Models;

namespace TaskManagerAPI1.Services.Interfaces
{
    public interface ITaskService
    {
        Task<TaskItem?> GetTaskAsync(int id, User currentUser);
        Task<IEnumerable<TaskItem>> GetAllTasksAsync(User currentUser);
        Task<IEnumerable<TaskItem>> GetUserTasksAsync(int userId);
        Task<TaskItem> CreateTaskAsync(TaskItem task, User currentUser);
        Task UpdateTaskAsync(TaskItem task, User currentUser);
        Task DeleteTaskAsync(int id, User currentUser);
    }

}

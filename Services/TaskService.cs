using TaskManagerAPI1.Models;
using TaskManagerAPI1.Repositories.Interface;
using TaskManagerAPI1.Services.Interfaces;

namespace TaskManagerAPI1.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repo;

        public TaskService(ITaskRepository repo)
        {
            _repo = repo;
        }

        public async Task<TaskItem?> GetTaskAsync(int id, User currentUser)
        {
            var task = await _repo.GetByIdAsync(id);
            if (task == null) return null;

            if (currentUser.Role == Role.Admin || task.AssignedUserId == currentUser.Id)
                return task;

            throw new UnauthorizedAccessException("Access denied.");
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync(User currentUser)
        {
            if (currentUser.Role != Role.Admin)
                throw new UnauthorizedAccessException("Only admins can view all tasks.");

            return await _repo.GetAllAsync();
        }

        public async Task<IEnumerable<TaskItem>> GetUserTasksAsync(int userId)
        {
            return await _repo.GetByUserIdAsync(userId);
        }

        public async Task<TaskItem> CreateTaskAsync(TaskItem task, User currentUser)
        {
            if (currentUser.Role != Role.Admin)
                throw new UnauthorizedAccessException("Only admins can create tasks.");

            return await _repo.AddAsync(task);
        }

        public async Task UpdateTaskAsync(TaskItem task, User currentUser)
        {
            var existing = await _repo.GetByIdAsync(task.Id);
            if (existing == null)
                throw new KeyNotFoundException("Task not found.");

            if (currentUser.Role == Role.Admin)
            {
                await _repo.UpdateAsync(task);
            }
            else if (existing.AssignedUserId == currentUser.Id)
            {
                existing.Status = task.Status;
                await _repo.UpdateAsync(existing);
            }
            else
            {
                throw new UnauthorizedAccessException("Access denied.");
            }
        }

        public async Task DeleteTaskAsync(int id, User currentUser)
        {
            if (currentUser.Role != Role.Admin)
                throw new UnauthorizedAccessException("Only admins can delete tasks.");

            await _repo.DeleteAsync(id);
        }

    }
}

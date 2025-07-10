using TaskManagerAPI1.Models;

namespace TaskManagerAPI1.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }

}

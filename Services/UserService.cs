using TaskManagerAPI1.Models;
using TaskManagerAPI1.Repositories.Interface;
using TaskManagerAPI1.Services.Interfaces;

namespace TaskManagerAPI1.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo) => _repo = repo;

        public Task<User> GetUserAsync(int id) => _repo.GetByIdAsync(id);
        public Task<IEnumerable<User>> GetAllUsersAsync() => _repo.GetAllAsync();
        public Task<User> CreateUserAsync(User user) => _repo.AddAsync(user);
        public Task UpdateUserAsync(User user) => _repo.UpdateAsync(user);
        public Task DeleteUserAsync(int id) => _repo.DeleteAsync(id);
    }

}

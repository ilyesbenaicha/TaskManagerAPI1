using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI1.Models;
using TaskManagerAPI1.Services.Interfaces;

namespace TaskManagerAPI1.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        public UsersController(IUserService service) => _service = service;

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _service.GetUserAsync(id));

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllUsersAsync());

        [HttpPost]
        public async Task<IActionResult> Create(User user) => Ok(await _service.CreateUserAsync(user));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User user)
        {
            user.Id = id;
            await _service.UpdateUserAsync(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteUserAsync(id);
            return NoContent();
        }

    }
}

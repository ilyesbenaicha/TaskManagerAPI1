using Microsoft.AspNetCore.Mvc;
using TaskManagerAPI1.Models;
using TaskManagerAPI1.Services.Interfaces;

namespace TaskManagerAPI.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _service;

    public TasksController(ITaskService service)
    {
        _service = service;
    }

    private User GetCurrentUser()
    {
        return HttpContext.Items["User"] as User ?? throw new UnauthorizedAccessException("User not found.");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var user = GetCurrentUser();
        var task = await _service.GetTaskAsync(id, user);
        return Ok(task);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var user = GetCurrentUser();
        var tasks = await _service.GetAllTasksAsync(user);
        return Ok(tasks);
    }

    [HttpGet("my")]
    public async Task<IActionResult> GetMyTasks()
    {
        var user = GetCurrentUser();
        var tasks = await _service.GetUserTasksAsync(user.Id);
        return Ok(tasks);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TaskItem task)
    {
        var user = GetCurrentUser();
        var created = await _service.CreateTaskAsync(task, user);
        return Ok(created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TaskItem task)
    {
        var user = GetCurrentUser();
        task.Id = id;
        await _service.UpdateTaskAsync(task, user);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var user = GetCurrentUser();
        await _service.DeleteTaskAsync(id, user);
        return NoContent();
    }
}
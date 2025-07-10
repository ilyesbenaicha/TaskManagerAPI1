using TaskManagerAPI1.Models;

namespace TaskManagerAPI1.Data
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                var admin = new User { Id = 1, Username = "admin", Role = Role.Admin };
                var user = new User { Id = 2, Username = "user", Role = Role.User };
                context.Users.AddRange(admin, user);

                context.Tasks.AddRange(
                    new TaskItem { Id = 1, Title = "Task 1", Description = "Admin Task", Status = "Open", AssignedUserId = 1 },
                    new TaskItem { Id = 2, Title = "Task 2", Description = "User Task", Status = "In Progress", AssignedUserId = 2 },
                    new TaskItem { Id = 3, Title = "Task 3", Description = "Another User Task", Status = "Open", AssignedUserId = 2 }
                );

                context.SaveChanges();
            }
        }

    }
}
using TaskManagerAPI1.Data;

namespace TaskManagerAPI1.Middleware
{
    public class RoleBasedAccessMiddleware
    {
        private readonly RequestDelegate _next;

        public RoleBasedAccessMiddleware(RequestDelegate next) => _next = next;

        public async Task Invoke(HttpContext context, AppDbContext db)
        {
            var userId = context.Request.Headers["X-User-Id"].FirstOrDefault();
            if (int.TryParse(userId, out int id))
            {
                var user = await db.Users.FindAsync(id);
                if (user != null)
                {
                    context.Items["User"] = user;
                }
            }
            await _next(context);
        }

    }
}
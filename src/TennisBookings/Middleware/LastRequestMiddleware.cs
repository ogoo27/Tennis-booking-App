namespace TennisBookings.Middleware;

public class LastRequestMiddleware
{
    private readonly RequestDelegate _next;

    public LastRequestMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, UserManager<TennisBookingsUser> userManager)
    {
        if (context.User?.Identity != null && context.User.Identity.IsAuthenticated)
        {
            var user = await userManager.FindByNameAsync(context.User.Identity.Name);

            if (user != null)
            {
                user.LastRequestUtc = DateTime.UtcNow;

                await userManager.UpdateAsync(user);
            }
        }

        await _next(context);
    }
}

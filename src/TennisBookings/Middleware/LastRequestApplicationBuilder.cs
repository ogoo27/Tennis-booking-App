namespace TennisBookings.Middleware;

public static class LastRequestApplicationBuilder
{
    public static IApplicationBuilder UseLastRequestTracking(this IApplicationBuilder builder)
    {
        builder.UseMiddleware<LastRequestMiddleware>();
        return builder;
    }
}

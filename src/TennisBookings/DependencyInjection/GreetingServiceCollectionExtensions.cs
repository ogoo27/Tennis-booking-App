using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TennisBookings.DependencyInjection;

public static class GreetingServiceCollectionExtensions
{
	public static IServiceCollection AddGreetings(this IServiceCollection services)
	{
		services.TryAddSingleton<GreetingService>();

		services.TryAddSingleton<IHomePageGreetingService>(sp =>
			sp.GetRequiredService<GreetingService>());

		services.TryAddSingleton<IGreetingService>(sp =>
			sp.GetRequiredService<GreetingService>());

		return services;
	}
}

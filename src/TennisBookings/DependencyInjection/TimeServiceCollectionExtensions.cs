using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TennisBookings.DependencyInjection;

public static class TimeServiceCollectionExtensions
{
	public static IServiceCollection AddTimeServices(this IServiceCollection services)
	{
		services.TryAddSingleton<IUtcTimeService, TimeService>();

		return services;
	}
}

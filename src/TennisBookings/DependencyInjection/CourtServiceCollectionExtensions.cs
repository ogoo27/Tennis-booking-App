using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TennisBookings.DependencyInjection;

public static class CourtServiceCollectionExtensions
{
	// These are no longer registered here and will be registered by Autofac
	public static IServiceCollection AddCourtServices(this IServiceCollection services)
	{
		services.TryAddScoped<ICourtMaintenanceService, CourtMaintenanceService>();

		return services;
	}
}

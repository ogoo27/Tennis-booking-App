using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TennisBookings.DependencyInjection;

public static class UnavailabilityServiceCollectionExtensions
{
	public static IServiceCollection AddCourtUnavailability(this IServiceCollection services)
	{
		services.TryAddEnumerable(new[]
		{
			ServiceDescriptor.Scoped<IUnavailabilityProvider, ClubClosedUnavailabilityProvider>(),
			ServiceDescriptor.Scoped<IUnavailabilityProvider, ClubClosedUnavailabilityProvider>(),
			ServiceDescriptor.Scoped<IUnavailabilityProvider, UpcomingHoursUnavailabilityProvider>(),
			ServiceDescriptor.Scoped<IUnavailabilityProvider, OutsideCourtUnavailabilityProvider>(),
			ServiceDescriptor.Scoped<IUnavailabilityProvider, CourtBookingUnavailabilityProvider>()
		}); // register multiple implementations manually

		return services;
	}
}

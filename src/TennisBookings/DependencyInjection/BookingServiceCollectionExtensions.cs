using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TennisBookings.DependencyInjection;

public static class BookingServiceCollectionExtensions
{
	public static IServiceCollection AddBookingServices(this IServiceCollection services)
	{
		services.TryAddScoped<ICourtService, CourtService>();
		services.TryAddScoped<ICourtBookingManager, CourtBookingManager>();
		services.TryAddScoped<IBookingService, BookingService>();
		services.TryAddScoped<ICourtBookingService, CourtBookingService>();

		return services;
	}
}

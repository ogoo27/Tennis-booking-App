using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace TennisBookings.DependencyInjection;

public static class ConfigurationServiceCollectionExtensions
{
	public static IServiceCollection AddAppConfiguration(this IServiceCollection services, IConfiguration config)
	{
		services.Configure<ClubConfiguration>(config.GetSection("ClubSettings"));
		services.Configure<BookingConfiguration>(config.GetSection("CourtBookings"));
		services.Configure<MembershipConfiguration>(config.GetSection("Membership"));
		services.Configure<ContentConfiguration>(config.GetSection("Content"));

		services.TryAddSingleton<IFeaturesConfiguration>(sp =>
			sp.GetRequiredService<IOptions<FeaturesConfiguration>>().Value); // forwarding via implementation factory

		services.TryAddSingleton<IBookingConfiguration>(sp =>
			sp.GetRequiredService<IOptions<BookingConfiguration>>().Value); // forwarding via implementation factory

		services.TryAddSingleton<IClubConfiguration>(sp =>
			sp.GetRequiredService<IOptions<ClubConfiguration>>().Value); // forwarding via implementation factory

		return services;
	}
}

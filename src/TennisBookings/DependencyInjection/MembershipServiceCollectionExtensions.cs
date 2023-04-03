using Microsoft.Extensions.DependencyInjection.Extensions;
using TennisBookings.Services.Membership;

namespace TennisBookings.DependencyInjection;

public static class MembershipServiceCollectionExtensions
{
	public static IServiceCollection AddMembershipServices(this IServiceCollection services)
	{
		services.TryAddTransient<IMembershipAdvertBuilder, MembershipAdvertBuilder>();
		services.TryAddScoped<IMembershipAdvert>(sp =>
		{
			var builder = sp.GetRequiredService<IMembershipAdvertBuilder>();

			builder.WithDiscount(10m);

			return builder.Build();
		}); // implementation factory for complex service construction

		return services;
	}
}

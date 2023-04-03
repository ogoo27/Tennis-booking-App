using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TennisBookings.DependencyInjection;

public static class AuditingServiceCollectionExtensions
{
	public static IServiceCollection AddAuditing(this IServiceCollection services)
	{
		services.TryAddScoped(typeof(IAuditor<>), typeof(Auditor<>)); // open generic registration

		return services;
	}
}

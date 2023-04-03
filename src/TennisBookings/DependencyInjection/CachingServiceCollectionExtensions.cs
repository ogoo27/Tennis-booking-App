using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TennisBookings.DependencyInjection;

public static class CachingServiceCollectionExtensions
{
	public static IServiceCollection AddCaching(this IServiceCollection services)
	{
		services.AddDistributedMemoryCache();

		services.TryAddSingleton(typeof(IDistributedCache<>), typeof(DistributedCache<>)); // open generic registration

		services.TryAddSingleton<IDistributedCacheFactory, DistributedCacheFactory>();

		return services;
	}
}

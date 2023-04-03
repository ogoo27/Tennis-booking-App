using Microsoft.Extensions.DependencyInjection.Extensions;
using TennisBookings.External;

namespace TennisBookings.DependencyInjection;

public static class WeatherServiceCollectionExtensions
{
	public static IServiceCollection AddWeatherForecasting(this IServiceCollection services)
	{
		services.AddHttpClient<IWeatherApiClient, WeatherApiClient>();
		services.TryAddSingleton<IWeatherForecaster, RandomWeatherForecaster>();
		services.Decorate<IWeatherForecaster, CachedWeatherForecaster>();

		return services;
	}
}

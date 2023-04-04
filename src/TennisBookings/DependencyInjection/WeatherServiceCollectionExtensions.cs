using Microsoft.Extensions.DependencyInjection.Extensions;
using TennisBookings.External;
using TennisBookings.Services.Weather;

namespace TennisBookings.DependencyInjection;

public static class WeatherServiceCollectionExtensions
{
	public static IServiceCollection AddWeatherForecasting(this IServiceCollection services,
		IConfiguration config)
	{
		if(config.GetValue<bool>("Features:WeatherForecasting:EnableWeatherForecasting"))
		{
			services.AddHttpClient<IWeatherApiClient, WeatherApiClient>();
			services.TryAddSingleton<IWeatherForecaster, WeatherForecaster>();
			services.Decorate<IWeatherForecaster, CachedWeatherForecaster>();
		}
		else
		{
			services.TryAddSingleton<IWeatherForecaster, DisabledWeatherForecaster>();


		}


		return services;
	}
}

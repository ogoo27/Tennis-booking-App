using TennisBookings.External;

namespace TennisBookings.Services.Weather;

public class WeatherForecaster : IWeatherForecaster
{
	private readonly IWeatherApiClient _weatherApiClient;

	public WeatherForecaster(IWeatherApiClient weatherApiClient)
	{
		_weatherApiClient = weatherApiClient;
	}

	public bool ForecastEnabled => true;

	public async Task<WeatherResult> GetCurrentWeatherAsync(string city)
	{
		var currentWeather = await _weatherApiClient.GetWeatherForecastAsync(city);

		var result = new WeatherResult
		{
			City = currentWeather?.City ?? "UNKNOWN",
			Weather = currentWeather?.Weather ?? new WeatherCondition()
		};

		return result;
	}
}

namespace TennisBookings.Services.Weather;

public class DisabledWeatherForecaster : IWeatherForecaster
{
	public bool ForecastEnabled => false;

	public Task<WeatherResult> GetCurrentWeatherAsync(string city)
	{
		var result = new WeatherResult
		{
			City = city,
			Weather = new WeatherCondition()
		};

		return Task.FromResult(result);
	}
}

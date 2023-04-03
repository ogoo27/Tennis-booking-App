namespace TennisBookings.Shared.Weather;

public interface IWeatherForecaster
{
	bool ForecastEnabled { get; }

	Task<WeatherResult> GetCurrentWeatherAsync(string city);
}

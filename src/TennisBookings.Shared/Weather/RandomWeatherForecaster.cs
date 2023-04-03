namespace TennisBookings.Shared.Weather;

public class RandomWeatherForecaster : IWeatherForecaster
{
	private readonly Random _random = new();

	public bool ForecastEnabled => true;

	public Task<WeatherResult> GetCurrentWeatherAsync(string city)
	{
		var condition = _random.Next(1, 4);

		var currentWeather = condition switch
		{
			1 => new WeatherResult
			{
				City = city,
				Weather = new WeatherCondition
				{
					Summary = "Sun",
					Temperature = new Temperature(26, 32),
					Wind = new Wind(6, 190)
				}
			},
			2 => new WeatherResult
			{
				City = city,
				Weather = new WeatherCondition
				{
					Summary = "Rain",
					Temperature = new Temperature(8, 14),
					Wind = new Wind(3, 80)
				}
			},
			3 => new WeatherResult
			{
				City = city,
				Weather = new WeatherCondition
				{
					Summary = "Cloud",
					Temperature = new Temperature(12, 18),
					Wind = new Wind(1, 10)
				}
			},
			_ => new WeatherResult
			{
				City = city,
				Weather = new WeatherCondition
				{
					Summary = "Snow",
					Temperature = new Temperature(-2, 1),
					Wind = new Wind(8, 240)
				}
			},
		};

		return Task.FromResult(currentWeather);
	}
}

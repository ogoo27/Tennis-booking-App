using Microsoft.AspNetCore.Mvc;
using TennisBookings.Shared.Weather;

namespace WeatherService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CurrentWeatherController : ControllerBase
{
	private readonly IWeatherForecaster _weatherForecaster;

	public CurrentWeatherController(IWeatherForecaster weatherForecaster)
	{
		_weatherForecaster = weatherForecaster;
	}

	[HttpGet("{city}")]
	public async Task<ActionResult<WeatherResult>> Get(string city)
	{
		var currentWeather = await _weatherForecaster.GetCurrentWeatherAsync(city);

		return currentWeather;
	}
}

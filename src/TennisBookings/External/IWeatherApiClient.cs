using TennisBookings.External.Models;

namespace TennisBookings.External;

public interface IWeatherApiClient
{
    Task<WeatherApiResult?> GetWeatherForecastAsync(string city);
}

namespace TennisBookings.Shared.Weather;

public class WeatherResult
{
    public string City { get; init; } = "Unknown";

    public WeatherCondition Weather { get; init; } = new WeatherCondition();
}

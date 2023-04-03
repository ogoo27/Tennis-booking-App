namespace TennisBookings.Shared.Weather;

public class Temperature
{
    public Temperature(float min, float max)
    {
        Min = min;
        Max = max;
    }

    public float Min { get; init; }
    public float Max { get; init; }
}

namespace TennisBookings.Shared.Weather;

public class Wind
{
    public Wind(float speed, float degrees)
    {
        Speed = speed;
        Degrees = degrees;
    }

    public float Speed { get; init; }
    public float Degrees { get; init; }
}

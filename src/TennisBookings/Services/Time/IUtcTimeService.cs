namespace TennisBookings.Services.Time;

public interface IUtcTimeService
{
	DateTime CurrentUtcDateTime { get; }
}

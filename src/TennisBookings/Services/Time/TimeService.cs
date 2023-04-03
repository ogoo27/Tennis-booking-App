namespace TennisBookings.Services.Time;

public class TimeService : ITimeService, IUtcTimeService
{
	public DateTime CurrentTime => DateTime.Now;

	public DateTime CurrentUtcDateTime => DateTime.UtcNow;
}

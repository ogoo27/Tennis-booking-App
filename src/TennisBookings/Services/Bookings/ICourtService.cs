namespace TennisBookings.Services.Bookings;

public interface ICourtService
{
	Task<IEnumerable<Court>> GetOutdoorCourts();
	Task<HashSet<int>> GetCourtIds();
}

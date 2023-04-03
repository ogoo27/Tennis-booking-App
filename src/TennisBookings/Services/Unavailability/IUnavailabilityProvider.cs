namespace TennisBookings.Services.Unavailability;

public interface IUnavailabilityProvider
{
    Task<IEnumerable<HourlyUnavailability>> GetHourlyUnavailabilityAsync(DateTime date);

    Task<IEnumerable<int>> GetHourlyUnavailabilityAsync(DateTime date, int courtId);
}

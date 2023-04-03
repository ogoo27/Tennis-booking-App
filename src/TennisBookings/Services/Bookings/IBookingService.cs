namespace TennisBookings.Services.Bookings;

public interface IBookingService
{
	Task<HourlyAvailabilityDictionary> GetBookingAvailabilityForDateAsync(DateTime date);

	Task<int> GetMaxBookingSlotForCourtAsync(DateTime startTime, DateTime endTime, int courtId);
}

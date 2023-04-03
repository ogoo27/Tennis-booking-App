namespace TennisBookings.Services.Bookings;

public interface ICourtBookingManager
{
	Task<CourtBookingResult> MakeBookingAsync(DateTime startDateTime, DateTime endDateTime, int courtId, Member member);
}

namespace TennisBookings.Domain;

public class CourtBookingResult
{
	private CourtBookingResult(CourtBooking? booking, bool passedRules, IEnumerable<string>? errors)
	{
		CourtBooking = booking;
		BookingSuccessful = passedRules;
		Errors = errors ?? Array.Empty<string>();
	}

	public CourtBooking? CourtBooking { get; }

	public bool BookingSuccessful { get; }

	public IEnumerable<string> Errors { get; }

	public static CourtBookingResult Success(CourtBooking courtBooking) => new(courtBooking, true, null);

	public static CourtBookingResult Failure(IEnumerable<string> errors) => new(null, false, errors);
}

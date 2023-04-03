namespace TennisBookings.Services.Bookings.Rules;

public class MemberBookingsMustNotOverlapRule : IScopedCourtBookingRule
{
	private readonly ICourtBookingService _courtBookingService;

	public MemberBookingsMustNotOverlapRule(ICourtBookingService courtBookingService)
	{
		_courtBookingService = courtBookingService;
	}

	public string ErrorMessage => "You cannot make two bookings which overlap";

	public async Task<bool> CompliesWithRuleAsync(CourtBooking booking)
	{
		if (booking?.Member is null)
			return false;

		var todaysBookings = (await _courtBookingService
			.MemberBookingsForDayAsync(booking.StartDateTime.Date, booking.Member))
			.ToArray();

		if (!todaysBookings.Any())
			return true; // no bookings, so cannot be overlap

		var bookingHours = Enumerable.Range(booking.StartDateTime.Hour,
			booking.EndDateTime.Hour - booking.StartDateTime.Hour).ToArray();

		foreach (var existingBooking in todaysBookings)
		{
			for (var hour = existingBooking.StartDateTime.Hour; hour < existingBooking.EndDateTime.Hour; hour++)
			{
				if (bookingHours.Contains(hour))
				{
					return false;
				}
			}
		}

		return true;
	}
}

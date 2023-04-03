namespace TennisBookings.Services.Bookings.Rules;

public interface IBookingRuleProcessor
{
	Task<(bool, IEnumerable<string>)> PassesAllRulesAsync(CourtBooking courtBooking);
}

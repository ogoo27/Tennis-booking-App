namespace TennisBookings.Services.Bookings.Rules;

public interface ICourtBookingRule
{
	Task<bool> CompliesWithRuleAsync(CourtBooking booking);

	string ErrorMessage { get; }
}

public interface IScopedCourtBookingRule : ICourtBookingRule
{
}

public interface ISingletonCourtBookingRule : ICourtBookingRule
{
}

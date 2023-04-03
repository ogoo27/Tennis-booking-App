namespace TennisBookings.Areas.Admin.Models;

public class CourtBookingViewModel
{
	public int BookingId { get; set; }

	public string? MemberName { get; set; }

	public string? CourtName { get; set; }

	public DateTime StartDateTime { get; set; }

	public DateTime EndDateTime { get; set; }
}

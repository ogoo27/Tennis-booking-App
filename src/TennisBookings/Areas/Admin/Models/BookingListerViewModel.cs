namespace TennisBookings.Areas.Admin.Models;

public class BookingListerViewModel
{
	public bool CancelSuccessful { get; set; }

	public IEnumerable<IGrouping<DateTime, CourtBookingViewModel>>? CourtBookings { get; set; }

	public DateTime EndOfWeek { get; set; }
}

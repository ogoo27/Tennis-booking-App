#nullable disable
namespace TennisBookings.Data;

public class TennisBookingsUser : IdentityUser
{
	public virtual ICollection<CourtBooking> CourtBookings { get; set; } = Array.Empty<CourtBooking>();
	public virtual Member Member { get; set; }
	public DateTime LastRequestUtc { get; set; }
	public bool IsAdmin { get; set; }
}
#nullable restore

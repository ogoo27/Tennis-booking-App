namespace TennisBookings.Services.Bookings;

public class CourtBookingService : ICourtBookingService
{
	private readonly TennisBookingsDbContext _dbContext;
	private readonly IUtcTimeService _utcTimeService;

	public CourtBookingService(TennisBookingsDbContext dbContext, IUtcTimeService utcTimeService)
	{
		_dbContext = dbContext;
		_utcTimeService = utcTimeService;
	}

	public async Task CreateCourtBooking(CourtBooking courtBooking)
	{
		_dbContext.CourtBookings!.Add(courtBooking);

		await _dbContext.SaveChangesAsync();
	}

	public async Task<CourtBooking?> LoadBooking(int bookingId)
	{
		var booking = await _dbContext.CourtBookings!
			.AsNoTracking()
			.Include(x => x.Court)
			.Include(x => x.Member)
			.SingleOrDefaultAsync(x => x.Id == bookingId);

		return booking;
	}

	public async Task<bool> CancelBooking(int bookingId)
	{
		var booking = await _dbContext.CourtBookings!.FindAsync(bookingId);

		if (booking == null)
			return false;

		_dbContext.CourtBookings.Remove(booking);

		await _dbContext.SaveChangesAsync();

		return true;
	}

	public async Task<IEnumerable<CourtBooking>> BookingsUntilDateAsync(DateTime date)
	{
		var currentDate = _utcTimeService.CurrentUtcDateTime;
		var endTime = date.Date.AddDays(1).AddMilliseconds(-1);

		var bookings = await _dbContext.CourtBookings!
			.AsNoTracking()
			.Include(x => x.Court)
			.Include(x => x.Member)
			.Where(x => x.StartDateTime >= currentDate && x.EndDateTime < endTime)
			.ToListAsync();

		return bookings;
	}

	public async Task<IEnumerable<CourtBooking>> BookingsForDayAsync(DateTime date)
	{
		var endTime = date.Date.AddDays(1).AddMilliseconds(-1);

		var bookings = await _dbContext.CourtBookings!
			.AsNoTracking()
			.Where(x => x.StartDateTime >= date.Date && x.EndDateTime < endTime)
			.ToListAsync();

		return bookings;
	}

	public async Task<IEnumerable<CourtBooking>> CourtBookingsForDayAsync(DateTime date, int courtId)
	{
		var endTime = date.Date.AddDays(1).AddMilliseconds(-1);

		var bookings = await _dbContext.CourtBookings!
			.AsNoTracking()
			.Where(x => x.StartDateTime >= date.Date && x.EndDateTime < endTime && x.CourtId == courtId)
			.ToListAsync();

		return bookings;
	}

	public async Task<IEnumerable<CourtBooking>> MemberBookingsForDayAsync(DateTime date, Member member)
	{
		var endTime = date.Date.AddDays(1).AddMilliseconds(-1);

		var bookings = await _dbContext.CourtBookings!
			.AsNoTracking()
			.Where(x => x.StartDateTime >= date.Date && x.EndDateTime < endTime && x.Member == member)
			.ToListAsync();

		return bookings;
	}

	public async Task<IEnumerable<CourtBooking>> GetFutureBookingsForMemberAsync(Member member)
	{
		var currentDate = _utcTimeService.CurrentUtcDateTime;

		return await _dbContext.CourtBookings!
			.AsNoTracking()
			.Where(c => c.Member == member && c.StartDateTime >= currentDate)
			.OrderBy(x => x.StartDateTime)
			.ToListAsync();
	}

	public async Task<int> GetBookedHoursForMemberAsync(int memberId, DateTime date)
	{
		var member = await _dbContext.Members!.FindAsync(memberId);

		if (member == null)
			throw new Exception("Member not found"); // should have better error handling here

		return await GetBookedHoursForMemberAsync(member, date);
	}

	public async Task<int> GetBookedHoursForMemberAsync(Member member, DateTime date)
	{
		var endTime = date.Date.AddDays(1).AddMilliseconds(-1);

		var bookings = await _dbContext.CourtBookings!
			.AsNoTracking()
			.Where(c => c.Member == member && c.StartDateTime >= date.Date && c.EndDateTime <= endTime)
			.ToListAsync();

		var hoursBooked = 0;

		foreach (var booking in bookings)
		{
			var length = (booking.EndDateTime - booking.StartDateTime).Hours;
			hoursBooked += length;
		}

		return hoursBooked;
	}
}

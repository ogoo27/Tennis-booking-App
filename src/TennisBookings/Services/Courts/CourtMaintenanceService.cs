namespace TennisBookings.Services.Courts;

public class CourtMaintenanceService : ICourtMaintenanceService
{
	private readonly TennisBookingsDbContext _dbContext;
	private readonly IUtcTimeService _utcTimeService;

	public CourtMaintenanceService(TennisBookingsDbContext dbContext, IUtcTimeService utcTimeService)
	{
		_dbContext = dbContext;
		_utcTimeService = utcTimeService;
	}

	public async Task<IEnumerable<CourtMaintenanceSchedule>> GetUpcomingMaintenance()
	{
		return await _dbContext.CourtMaintenance!
			.AsNoTracking()
			.Include(x => x.Court)
			.Where(x => x.EndDate > _utcTimeService.CurrentUtcDateTime).ToListAsync();
	}
}

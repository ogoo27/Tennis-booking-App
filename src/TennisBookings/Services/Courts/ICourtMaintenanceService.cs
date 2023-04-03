namespace TennisBookings.Services.Courts;

public interface ICourtMaintenanceService
{
	Task<IEnumerable<CourtMaintenanceSchedule>> GetUpcomingMaintenance();
}

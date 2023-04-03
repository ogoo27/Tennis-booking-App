namespace TennisBookings.Areas.Admin.Models;

public class MaintenanceListerViewModel
{
	public IEnumerable<IGrouping<DateTime, CourtMaintenanceViewModel>> ScheduledMaintenanceWork { get; set; } = new List<IGrouping<DateTime, CourtMaintenanceViewModel>>();
}

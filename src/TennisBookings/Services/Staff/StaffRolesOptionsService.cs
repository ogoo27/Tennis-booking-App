namespace TennisBookings.Services.Staff;

public class StaffRolesOptionsService : IStaffRolesOptionsService
{
	public List<string> Roles { get; } = new List<string>
	{
		"Accounts Manager",
		"Cleaner",
		"Club Manager",
		"Coach",
		"Court Maintenance Worker",
		"Receptionist"
	};
}

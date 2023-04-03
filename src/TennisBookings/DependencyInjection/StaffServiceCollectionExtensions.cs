namespace TennisBookings.DependencyInjection;

public static class StaffServiceCollectionExtensions
{
	public static IServiceCollection AddStaffServices(this IServiceCollection services)
	{
		services.AddSingleton<IStaffRolesOptionsService, StaffRolesOptionsService>();

		return services;
	}
}

namespace TennisBookings.BackgroundService;

public class InitialiseDatabaseService : IHostedService
{
	private readonly IServiceScopeFactory _scopeFactory;

	private const string AdminEmail = "admin@example.com";
	private const string MemberEmail = "member@example.com";
	private const string AdminRole = "Admin";

	public InitialiseDatabaseService(IServiceScopeFactory scopeFactory) => _scopeFactory = scopeFactory;

	public async Task StartAsync(CancellationToken cancellationToken)
	{
		// Blocks until this is completed

		await using var serviceScope = _scopeFactory.CreateAsyncScope();

		var dbContext = serviceScope.ServiceProvider.GetRequiredService<TennisBookingsDbContext>();
		dbContext.Database.EnsureCreated();

		var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<TennisBookingsUser>>();
		var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<TennisBookingsRole>>();

		if (!await roleManager.RoleExistsAsync(AdminRole))
		{
			var adminRole = new TennisBookingsRole { Name = AdminRole };
			await roleManager.CreateAsync(adminRole);
		}

		var adminUser = new TennisBookingsUser()
		{
			UserName = AdminEmail,
			Email = AdminEmail,
			EmailConfirmed = true,
			IsAdmin = true
		};

		if (await userManager.FindByNameAsync(AdminEmail) is null)
		{
			var password = new PasswordHasher<TennisBookingsUser>();
			var hashed = password.HashPassword(adminUser, "password");
			adminUser.PasswordHash = hashed;

			var result = await userManager.CreateAsync(adminUser);

			if (result.Succeeded)
			{
				await userManager.AddToRoleAsync(adminUser, AdminRole);
			}
		}

		var memberUser = new TennisBookingsUser()
		{
			UserName = MemberEmail,
			Email = MemberEmail,
			EmailConfirmed = true,
			Member = new Member
			{
				Forename = "Steve",
				Surname = "Gordon",
				JoinDate = DateTime.UtcNow.Date
			}
		};

		if (await userManager.FindByNameAsync(MemberEmail) is null)
		{
			var password = new PasswordHasher<TennisBookingsUser>();
			var hashed = password.HashPassword(memberUser, "password");
			memberUser.PasswordHash = hashed;

			_ = await userManager.CreateAsync(memberUser);
		}
	}

	public Task StopAsync(CancellationToken cancellationToken)
	{
		return Task.CompletedTask;
	}
}

using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TennisBookings.DependencyInjection;

public static class NotificationsServiceCollectionExtensions
{
	public static IServiceCollection AddNotifications(this IServiceCollection services)
	{
		services.TryAddSingleton<EmailNotificationService>();
		services.TryAddSingleton<SmsNotificationService>();

		services.AddSingleton<INotificationService>(sp =>
			new CompositeNotificationService(
				new INotificationService[]
				{
					sp.GetRequiredService<EmailNotificationService>(),
					sp.GetRequiredService<SmsNotificationService>()
				})); // composite pattern

		return services;
	}
}

namespace TennisBookings.Services.Notifications;

public interface INotificationService
{
	Task SendAsync(string message, string userId);
}

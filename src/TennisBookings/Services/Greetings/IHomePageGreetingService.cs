namespace TennisBookings.Services.Greetings;

public interface IHomePageGreetingService
{
	[Obsolete("Prefer the GetRandomGreeting method defined in IGreetingService")]
	string GetRandomHomePageGreeting();
}

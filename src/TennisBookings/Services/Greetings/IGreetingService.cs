namespace TennisBookings.Services.Greetings;

public interface IGreetingService
{
    string GetRandomGreeting();

    string GetRandomLoginGreeting(string name);

    string GreetingColour { get; }
}

namespace TennisBookings.Services.Security;

public interface IAuditor<out T> : IAuditor
{
}

public interface IAuditor
{
	void RecordAction(string message);
}

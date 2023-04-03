namespace TennisBookings.Configuration;

public class ExternalServicesConfiguration
{
	public string Url { get; set; } = string.Empty;
	public int MinsToCache { get; set; } = 10;
}

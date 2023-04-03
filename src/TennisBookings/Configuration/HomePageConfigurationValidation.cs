using Microsoft.Extensions.Options;
using TennisBookings.Services;

namespace TennisBookings.Configuration;

public class HomePageConfigurationValidation
{
	private readonly WeatherForecastingConfiguration _weatherConfig;
	private readonly IProfanityChecker _profanityChecker;
	private readonly bool _checkForProfanity;

	public HomePageConfigurationValidation(
		IOptions<ContentConfiguration> contentConfig,
		IOptions<WeatherForecastingConfiguration> weatherConfig,
		IProfanityChecker profanityChecker)
	{
		_checkForProfanity = contentConfig.Value.CheckForProfanity;
		_weatherConfig = weatherConfig.Value;
		_profanityChecker = profanityChecker;
	}
}

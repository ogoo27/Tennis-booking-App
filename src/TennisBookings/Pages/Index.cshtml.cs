using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TennisBookings.Pages;

public class IndexModel : PageModel
{
	private const string DefaultForecastSectionTitle = "How's the weather";

	private readonly ILogger<IndexModel> _logger;
	private readonly IGreetingService _greetingService;
	private readonly IConfiguration _configuration;


	public IndexModel(
		ILogger<IndexModel> logger,		
		IGreetingService greetingService,
		IConfiguration configuration)
	{
		_logger = logger;
		_greetingService = greetingService;
		 _configuration = configuration;

	}

	public string WeatherDescription { get; private set; } =
			"We don't have the latest weather information right now, " +
			"please check again later.";

	public bool ShowWeatherForecast { get; private set; } = false;
	public string ForecastSectionTitle { get; private set; } =
		DefaultForecastSectionTitle;
	public bool ShowGreeting => !string.IsNullOrEmpty(Greeting);
	public string Greeting { get; private set; } = string.Empty;
	public string GreetingColour => _greetingService.GreetingColour;

	public async Task OnGet()
	{
		
	}
}

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TennisBookings.Pages;

public class IndexModel : PageModel
{
	private const string DefaultForecastSectionTitle = "How's the weather";

	private readonly ILogger<IndexModel> _logger;
	private readonly IGreetingService _greetingService;
	private readonly IConfiguration _configuration;
	private readonly IWeatherForecaster _weatherForecaster;

	public IndexModel(
		ILogger<IndexModel> logger,		
		IGreetingService greetingService,
		IConfiguration configuration,
		IWeatherForecaster weatherForecaster)
	{
		_logger = logger;
		_greetingService = greetingService;
		 _configuration = configuration;
		_weatherForecaster = weatherForecaster;
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
		//Binding congiguration to an instance of an object
		//The bind method takes in two parameters
		//The key of the configuration and the object instance
		var features = new Features();
		_configuration.Bind("Features:HomePage", features);

		if (features.EnableGreeting)
		{
			Greeting = _greetingService.GetRandomGreeting();

		}

		ShowWeatherForecast = features.EnableWeatherForecast;
		{
			var title = features.ForecastSectionTitle;
			ForecastSectionTitle = string.IsNullOrEmpty(title) ? DefaultForecastSectionTitle : title;

			var currentWeather = await _weatherForecaster
				.GetCurrentWeatherAsync("Eastbourne");

			if (currentWeather is not null)
			{
				switch (currentWeather.Weather.Summary)
				{
					case "Sun":
						WeatherDescription = "It's sunny right now. " +
							"A great day for tennis!";
						break;

					case "Cloud":
						WeatherDescription = "It's cloudy at the moment and  " +
							"the outdoor courts are available.";
						break;
					case "Rain":
						WeatherDescription = "We're sorry but it's raining now " +
							"No outdoor courts are available.";
						break;
					case "Snow":
						WeatherDescription = "It's snowing!! Outdoor courts " +
							"Outdoor courts will remain closed until the snow clears";
						break;
				}




				//var homePageFeatures = _configuration.GetSection("Features:HomePage");
				///if(homePageFeatures.GetValue<bool>("EnableGreeting"))
				//{
				//	Greeting = _greetingService.GetRandomGreeting();

				//}

				//Both will work but the first one is optimized
				//if (_configuration.GetValue<bool>("Features:HomePage:EnableGreeting"))
				//	Greeting = _greetingService.GetRandomGreeting();
				//}

				//var ShowWeatherForecast = homePageFeatures.GetValue<bool>("EnableWeatherForecast")
				//&& _weatherForecaster.ForecastEnabled;
				//if(ShowWeatherForecast)

				//var title = homePageFeatures["ForecastSectionTitle"];








			}


		}
	}

	//Create a private class to get new instance to bind configuration to
	//Property name must match the key name in the confoiguration file
	private class Features
	{
		public bool EnableGreeting { get; set; }
		public bool EnableWeatherForecast { get; set; }
		public string ForecastSectionTitle { get; set; }


	}
}

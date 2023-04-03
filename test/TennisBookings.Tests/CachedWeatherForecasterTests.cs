using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Moq;
using TennisBookings.Caching;
using TennisBookings.Configuration;
using TennisBookings.Shared.Weather;
using Xunit;

namespace TennisBookings.Tests;

public class CachedWeatherForecasterTests
{
	[Fact]
	public async Task GetCurrentWeatherAsync_CachesForCorrectPeriodOfTime()
	{
		//const int expectedMinsToCache = 101;

		//var minsToCache = -1;

		//var forecasterMock = new Mock<IWeatherForecaster>();
		//forecasterMock.Setup(x => x.GetCurrentWeatherAsync("city"))
		//	.ReturnsAsync(new WeatherResult { Weather = new WeatherCondition { Summary = "This is a weather description" } });

		//var cacheMock = new Mock<IDistributedCache<WeatherResult>>();
		//cacheMock.Setup(x => x.TryGetValueAsync(It.IsAny<string>())).
		//	ReturnsAsync((false, null));
		//cacheMock.Setup(x => x
		//	.SetAsync(It.IsAny<string>(), It.IsAny<WeatherResult>(), It.IsAny<int>()))
		//	.Callback<string, WeatherResult, int>((key, result, mins) => minsToCache = mins);

		//var optionsMock = new Mock<IOptionsMonitor<ExternalServicesConfiguration>>();
		//optionsMock.Setup(x => x.Get(ExternalServicesConfiguration.WeatherApi))
		//	.Returns(new ExternalServicesConfiguration { MinsToCache = expectedMinsToCache });

		//var sut = new CachedWeatherForecaster(forecasterMock.Object, cacheMock.Object, optionsMock.Object);

		//_ = await sut.GetCurrentWeatherAsync("city");

		//cacheMock.Verify(x => x.SetAsync(
		//	It.IsAny<string>(), It.IsAny<WeatherResult>(), It.IsAny<int>()), Times.Once);

		//Assert.Equal(expectedMinsToCache, minsToCache);
	}

	[Fact]
	public async Task GetCurrentWeatherAsync_CachesForCorrectPeriodOfTime_UsingStubsAndServiceProvider()
	{
		//const int expectedMinsToCache = 101;

		//var stubCache = new StubDistributedCache();

		//var options = new ServiceCollection()
		//	.Configure<ExternalServicesConfiguration>(
		//		ExternalServicesConfiguration.WeatherApi, opt =>
		//			opt.MinsToCache = expectedMinsToCache)
		//	.BuildServiceProvider()
		//	.GetRequiredService<IOptionsMonitor<ExternalServicesConfiguration>>();

		//var sut = new CachedWeatherForecaster(new StubWeatherForecaster(),
		//	stubCache, options);

		//_ = await sut.GetCurrentWeatherAsync();

		//Assert.True(stubCache.ItemCached);
		//Assert.Equal(expectedMinsToCache, stubCache.CachedForMins);
	}

	private class StubWeatherForecaster : IWeatherForecaster
	{
		public bool ForecastEnabled => true;

		public Task<WeatherResult> GetCurrentWeatherAsync(string city) =>
			Task.FromResult(new WeatherResult
			{
				City = city,
				Weather = new WeatherCondition { Summary = "Sun" }
			});
	}

	public class StubDistributedCache : IDistributedCache<WeatherResult>
	{
		public bool ItemCached { get; private set; }
		public int CachedForMins { get; private set; }

		public Task<WeatherResult?> GetAsync(string key) => throw new NotImplementedException();

		public Task RemoveAsync(string key) => throw new NotImplementedException();

		public Task SetAsync(string key, WeatherResult item, int minutesToCache)
		{
			ItemCached = true;
			CachedForMins = minutesToCache;
			return Task.CompletedTask;
		}

		public Task<(bool Found, WeatherResult? Value)> TryGetValueAsync(string key) =>
			Task.FromResult((false, (WeatherResult?)null));
	}
}

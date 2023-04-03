using Microsoft.Extensions.Options;
using TennisBookings.External.Models;
using Microsoft.Extensions.Caching.Memory;

namespace TennisBookings.External;

public class ProductsApiClient : IProductsApiClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ProductsApiClient> _logger;
    private readonly IMemoryCache _cache;
    private readonly IOptionsMonitor<ExternalServicesConfiguration> _productsApiConfig;

	private readonly bool _isConfigured = false;

	public ProductsApiClient(
		HttpClient httpClient,
		IOptionsMonitor<ExternalServicesConfiguration> options,
		ILogger<ProductsApiClient> logger, IMemoryCache cache)
    {
        var externalServicesConfiguration = options.Get("ProductsApi");

		if (!string.IsNullOrEmpty(externalServicesConfiguration.Url))
		{
			_isConfigured = true;
			httpClient.BaseAddress = new Uri(externalServicesConfiguration.Url);
		}

		_httpClient = httpClient;
        _logger = logger;
        _cache = cache;
        _productsApiConfig = options;
    }

    public async Task<ProductsApiResult?> GetProducts()
    {
		if (!_isConfigured)
			return null;

		const string cacheKey = "Products";

        if (_cache.TryGetValue<ProductsApiResult>(cacheKey, out var forecast))
        {
            return forecast;
        }

        const string path = "api/products";

        try
        {
            var request = new HttpRequestMessage(HttpMethod.Get, path);

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var content = await response.Content.ReadAsAsync<ProductsApiResult>();

            if (content != null)
            {
                var cacheOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_productsApiConfig.Get("ProductsApi").MinsToCache)
                };

                _cache.Set(cacheKey, content, cacheOptions);
            }

            return content;
        }
        catch (HttpRequestException e)
        {
            _logger.LogError(e, "Failed to get products data from API");
        }

        return null;
    }
}

using TennisBookings.External;

namespace TennisBookings.DependencyInjection;

public static class ProductsServiceCollectionExtensions
{
	public static IServiceCollection AddProducts(this IServiceCollection services)
	{
		services.AddHttpClient<IProductsApiClient, ProductsApiClient>();		
		return services;
	}
}

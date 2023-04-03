using TennisBookings.External.Models;

namespace TennisBookings.External;

public interface IProductsApiClient
{
    Task<ProductsApiResult?> GetProducts();
}

namespace TennisBookings.External.Models;

public class ProductsApiResult
{
    public int TotalProducts { get; set; }

    public IReadOnlyCollection<Product>? Products { get; set; }
}

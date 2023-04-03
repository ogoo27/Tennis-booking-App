namespace BrandedProducts.Api.Models;

public record ProductsResultOutputModel
{
	public int TotalProducts => Products.Count;
	public IReadOnlyCollection<ProductOutputModel> Products { get; init; } = Array.Empty<ProductOutputModel>();
}

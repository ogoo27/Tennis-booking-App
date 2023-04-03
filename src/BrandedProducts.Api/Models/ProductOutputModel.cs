namespace BrandedProducts.Api.Models;

public record ProductOutputModel
{
	public string Name { get; init; } = string.Empty;
	public string Description { get; init; } = string.Empty;
	public double Price { get; init; }
}

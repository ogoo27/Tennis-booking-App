using BrandedProducts.Api.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var products = new List<ProductOutputModel>
{
	new ProductOutputModel
	{
		Name = "ProTech Racket",
		Description = "The best racket on the market today! Never miss a shot.",
		Price = 150.00
	},

	new ProductOutputModel
	{
		Name = "Yellow Spheres",
		Description = "Performance tennis balls with fantastic durability.",
		Price = 15.75
	},

	new ProductOutputModel
	{
		Name = "Go-faster Shorts",
		Description = "Never be late to the ball again with our patented go-faster fabric technology.",
		Price = 45.95
	}
};

app.Use(async (context, next) =>
{
	//if (context.Request.Headers["ApiKey"] != "SUPERSECRETKEY")
	//{
	//	context.Response.StatusCode = StatusCodes.Status401Unauthorized;
	//	return;
	//}

	await next.Invoke();
});

app.MapGet("/api/products", () =>
{
	return new ProductsResultOutputModel
	{
		Products = products
	};
});

app.Run();

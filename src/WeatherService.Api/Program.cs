using TennisBookings.Shared.Weather;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IWeatherForecaster, RandomWeatherForecaster>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();

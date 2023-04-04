#region Global Usings
global using Microsoft.AspNetCore.Identity;

global using TennisBookings;
global using TennisBookings.Data;
global using TennisBookings.Domain;
global using TennisBookings.Extensions;
global using TennisBookings.Configuration;
global using TennisBookings.Caching;
global using TennisBookings.Shared.Weather;
global using TennisBookings.DependencyInjection;
global using TennisBookings.Services.Bookings;
global using TennisBookings.Services.Greetings;
global using TennisBookings.Services.Unavailability;
global using TennisBookings.Services.Bookings.Rules;
global using TennisBookings.Services.Notifications;
global using TennisBookings.Services.Time;
global using TennisBookings.Services.Staff;
global using TennisBookings.Services.Courts;
global using TennisBookings.Services.Security;
global using Microsoft.EntityFrameworkCore;
#endregion

using Microsoft.Data.Sqlite;
using TennisBookings.BackgroundService;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

var builder = WebApplication.CreateBuilder(args);
//builder.Configuration.AddJsonFile("appSettings.Development.json", false, true);
using var connection = new SqliteConnection(builder.Configuration
	.GetConnectionString("SqliteConnection"));

await connection.OpenAsync();

//Registration of services
builder.Services
	.AddAppConfiguration(builder.Configuration)
	.AddBookingServices()
	.AddBookingRules()
	.AddCourtUnavailability()
	.AddMembershipServices()
	.AddStaffServices()
	.AddCourtServices()
	.AddWeatherForecasting(builder.Configuration)
	.AddProducts()
	.AddNotifications()
	.AddGreetings()
	.AddCaching()
	.AddTimeServices()
	.AddProfanityValidationService()
	.AddAuditing();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(options =>
{
	options.Conventions.AuthorizePage("/Bookings");
	options.Conventions.AuthorizePage("/BookCourt");
	options.Conventions.AuthorizePage("/FindAvailableCourts");
	options.Conventions.Add(new PageRouteTransformerConvention(new SlugifyParameterTransformer()));
});

// Add services to the container.
builder.Services.AddDbContext<TennisBookingsDbContext>(options => options.UseSqlite(connection));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//Microsoft Identity services uses the DbContext to access the user data
builder.Services.AddIdentity<TennisBookingsUser, TennisBookingsRole>(options => options.SignIn.RequireConfirmedAccount = false)
	.AddEntityFrameworkStores<TennisBookingsDbContext>()
	.AddDefaultUI()
	.AddDefaultTokenProviders();

builder.Services.AddHostedService<InitialiseDatabaseService>();

builder.Services.ConfigureApplicationCookie(options =>
{
	options.AccessDeniedPath = "/identity/account/access-denied";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Error");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

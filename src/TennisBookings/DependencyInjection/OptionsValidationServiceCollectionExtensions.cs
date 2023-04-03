using Microsoft.Extensions.DependencyInjection.Extensions;
using TennisBookings.Services;

namespace TennisBookings.DependencyInjection;

public static class OptionsValidationServiceCollectionExtensions
{
	public static IServiceCollection AddProfanityValidationService(this IServiceCollection services)
	{
		services.TryAddSingleton<IProfanityChecker, ProfanityChecker>();

		return services;
	}
}

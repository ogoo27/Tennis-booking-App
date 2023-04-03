using Microsoft.Extensions.Options;
using Moq;
using TennisBookings.Configuration;
using TennisBookings.Services.Bookings.Rules;
using Xunit;

namespace TennisBookings.Tests;

public class ClubIsOpenRuleTests
{
	[Fact]
	public async Task CompliesWithRuleAsync_ReturnsTrue_WhenValuesAreValid()
	{
		//var sut = new ClubIsOpenRule();

		//var result = await sut.CompliesWithRuleAsync(new Data.CourtBooking()
		//{
		//	StartDateTime = new DateTime(2019, 01, 01, 10, 00, 00),
		//	EndDateTime = new DateTime(2019, 01, 01, 12, 00, 00)
		//});

		//Assert.True(result);
	}

	[Fact]
	public async Task CompliesWithRuleAsync_ReturnsFalse_WhenBookingEndsAfterClubIsClosed()
	{
		//var sut = new ClubIsOpenRule();

		//var result = await sut.CompliesWithRuleAsync(new Data.CourtBooking()
		//{
		//	StartDateTime = new DateTime(2019, 01, 01, 21, 00, 00),
		//	EndDateTime = new DateTime(2019, 01, 01, 23, 00, 00) // this is too late
		//});

		//Assert.False(result);
	}
}

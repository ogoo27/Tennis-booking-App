namespace TennisBookings.Services.Membership;

public interface IMembershipAdvertBuilder
{
	MembershipAdvert Build();
	MembershipAdvertBuilder WithDiscount(decimal discount);
}

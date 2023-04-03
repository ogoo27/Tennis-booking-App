namespace TennisBookings.Services;

public interface IProfanityChecker
{
    bool ContainsProfanity(string? input);
}

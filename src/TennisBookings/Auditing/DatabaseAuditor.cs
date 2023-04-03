namespace TennisBookings.Auditing;

public class DatabaseAuditor : IAuditor
{
    public string SourceName { get; }

    public DatabaseAuditor(string sourceName)
    {
        SourceName = sourceName;
    }

    public void RecordAction(string message)
    {
        // imagine writing audit data to a database
    }
}

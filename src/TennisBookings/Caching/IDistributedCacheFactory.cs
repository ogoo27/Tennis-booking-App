namespace TennisBookings.Caching;

public interface IDistributedCacheFactory
{
	IDistributedCache<T> GetCache<T>();
}

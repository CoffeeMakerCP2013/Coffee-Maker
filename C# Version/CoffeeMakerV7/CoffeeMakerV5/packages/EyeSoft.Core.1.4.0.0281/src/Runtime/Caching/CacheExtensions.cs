namespace EyeSoft.Runtime.Caching
{
	public static class CacheExtensions
	{
		public static T Get<T>(this ICache cache, string key)
		{
			return (T)cache.Get(key);
		}

		public static bool TryGetValue<T>(this ICache cache, string key, out T value)
		{
			object item;

			var success = cache.TryGetValue(key, out item);

			if (success)
			{
				value = (T)item;
			}
			else
			{
				value = default(T);
			}

			return success;
		}
	}
}
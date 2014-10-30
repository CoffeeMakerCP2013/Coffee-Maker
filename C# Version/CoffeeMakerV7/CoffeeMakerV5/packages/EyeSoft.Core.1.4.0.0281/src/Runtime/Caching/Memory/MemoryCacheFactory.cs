namespace EyeSoft.Runtime.Caching.Memory
{
	public class MemoryCacheFactory : ICacheFactory
	{
		private readonly MemoryCache cache;

		public MemoryCacheFactory(string name = "Cache")
		{
			cache = new MemoryCache(name);
		}

		public MemoryCacheFactory()
		{
			cache = new MemoryCache();
		}

		public ICache Create()
		{
			return cache;
		}

		public void Dispose()
		{
			cache.Dispose();
		}
	}
}
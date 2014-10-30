namespace EyeSoft.Runtime.Caching.Memory
{
	using System;
	using System.Globalization;
	using System.Runtime.Caching;

	public class MemoryCache : ICache
	{
		private readonly System.Runtime.Caching.MemoryCache cache;

		public MemoryCache()
			: this(new System.Runtime.Caching.MemoryCache(DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture)))
		{
		}

		public MemoryCache(System.Runtime.Caching.MemoryCache cache)
		{
			this.cache = cache;
		}

		public MemoryCache(string name)
		{
			cache = new System.Runtime.Caching.MemoryCache(name);
		}

		public long Count
		{
			get
			{
				return cache.GetCount();
			}
		}

		public bool Remove(string key)
		{
			cache.Remove(key);

			return true;
		}

		public void Put(string key, object value)
		{
			cache.Add(new CacheItem(key, value), new CacheItemPolicy());
		}

		public object Get(string key)
		{
			return cache.Get(key);
		}

		public bool TryGetValue(string key, out object value)
		{
			if (cache.Contains(key))
			{
				value = cache.Get(key);
				return true;
			}

			value = null;
			return false;
		}

		public void Clear()
		{
			cache.Trim(100);
		}

		public void Dispose()
		{
			cache.Dispose();
		}
	}
}
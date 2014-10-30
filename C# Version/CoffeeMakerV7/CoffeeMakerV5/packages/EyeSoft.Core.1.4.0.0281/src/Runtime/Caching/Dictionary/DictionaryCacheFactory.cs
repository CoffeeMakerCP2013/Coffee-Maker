namespace EyeSoft.Runtime.Caching.Dictionary
{
	using System.Collections.Generic;

	public class DictionaryCacheFactory : ICacheFactory
	{
		private readonly IDictionary<string, object> data = new Dictionary<string, object>();

		public ICache Create()
		{
			var cache = new DictionaryCache(data);
			return cache;
		}

		public void Dispose()
		{
		}
	}
}
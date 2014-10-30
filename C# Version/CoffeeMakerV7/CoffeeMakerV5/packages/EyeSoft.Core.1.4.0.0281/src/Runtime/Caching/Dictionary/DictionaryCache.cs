namespace EyeSoft.Runtime.Caching.Dictionary
{
	using System.Collections.Generic;

	public class DictionaryCache : ICache
	{
		private readonly IDictionary<string, object> data;

		public DictionaryCache(IDictionary<string, object> data)
		{
			this.data = data;
		}

		public long Count
		{
			get
			{
				return data.Count;
			}
		}

		public bool Remove(string key)
		{
			return data.Remove(key);
		}

		public void Put(string key, object value)
		{
			data.Add(key, value);
		}

		public object Get(string key)
		{
			return data[key];
		}

		public bool TryGetValue(string key, out object value)
		{
			return data.TryGetValue(key, out value);
		}

		public void Clear()
		{
			data.Clear();
		}

		public void Dispose()
		{
		}
	}
}
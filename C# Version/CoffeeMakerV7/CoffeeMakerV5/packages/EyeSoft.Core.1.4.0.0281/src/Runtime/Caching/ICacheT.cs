namespace EyeSoft.Runtime.Caching
{
	using System;

	public interface ICache<T> : IDisposable
	{
		long Count { get; }

		bool Remove(string key);

		void Put(string key, T value);

		T Get(string key);

		bool TryGetValue(string key, out T value);

		void Clear();
	}
}
namespace EyeSoft.Runtime.Caching
{
	using System;

	public interface ICacheFactory : IDisposable
	{
		ICache Create();
	}
}
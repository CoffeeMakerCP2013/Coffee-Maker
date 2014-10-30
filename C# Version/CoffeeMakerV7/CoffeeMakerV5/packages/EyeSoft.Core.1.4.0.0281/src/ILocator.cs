namespace EyeSoft
{
	using System;
	using System.Collections.Generic;

	public interface ILocator : IDisposable
	{
		object GetInstance(Type serviceType, IDictionary<string, object> parameters);

		T GetInstance<T>(IDictionary<string, object> parameters);

		object GetInstance(Type serviceType);

		object GetInstance(Type serviceType, string key);

		IEnumerable<object> GetAllInstances(Type serviceType);

		TService GetInstance<TService>();

		TService GetInstance<TService>(string key);

		IEnumerable<TService> GetAllInstances<TService>();

		void Release(object obj);
	}
}
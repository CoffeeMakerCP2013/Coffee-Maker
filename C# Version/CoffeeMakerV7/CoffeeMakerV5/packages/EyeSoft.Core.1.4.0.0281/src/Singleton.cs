namespace EyeSoft
{
	using System;

	public class Singleton<T>
	{
		private static readonly object locker = new object();

		private readonly string typeName = typeof(T).FullName;

		private T singletonInstance;

		private bool initialized;

		private bool assigned;

		private bool used;

		public Singleton()
		{
		}

		public Singleton(T instance)
		{
			Enforce.Argument(() => instance);

			singletonInstance = instance;

			initialized = true;
		}

		public T Instance
		{
			get
			{
				lock (locker)
				{
					if (!initialized)
					{
						new InvalidOperationException(
							"The singleton instance of type {Type} was not initialized.".NamedFormat(typeName))
							.Throw();
					}
				}

				used = true;

				return singletonInstance;
			}
		}

		public void Set(T instance)
		{
			lock (locker)
			{
				Enforce.Argument(() => instance);

				if (used)
				{
					new InvalidOperationException(
						"The singleton instance of type {Type} can be changed only before any usage.".NamedFormat(typeName))
						.Throw();
				}

				if (assigned)
				{
					new InvalidOperationException(
						"The singleton instance of type {Type} can be assigned only one time.".NamedFormat(typeName))
						.Throw();
				}

				singletonInstance = instance;

				initialized = true;

				assigned = true;
			}
		}
	}
}
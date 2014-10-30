namespace EyeSoft.Extensions
{
	using System.ComponentModel;
	using System.Diagnostics;

	internal class ObjectExtender<T> : IObjectExtender<T>
	{
		private readonly T obj;

		public ObjectExtender(T obj)
		{
			this.obj = obj;
		}

		public T Instance
		{
			get { return obj; }
		}
	}
}
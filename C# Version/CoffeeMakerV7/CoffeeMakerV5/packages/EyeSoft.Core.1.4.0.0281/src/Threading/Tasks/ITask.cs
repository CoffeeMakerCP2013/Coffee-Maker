namespace EyeSoft.Threading.Tasks
{
	using System;

	public interface ITask : IAsyncResult, IDisposable
	{
		AggregateException Exception { get; }

		bool IsFaulted { get; }

		bool IsCanceled { get; }

		void Wait();

		ITask ContinueWith(Action<ITask> action);
	}
}
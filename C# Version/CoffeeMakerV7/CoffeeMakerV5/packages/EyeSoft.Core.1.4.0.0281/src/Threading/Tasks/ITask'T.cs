namespace EyeSoft.Threading.Tasks
{
	using System;

	public interface ITask<out TResult> : ITask
	{
		TResult Result { get; }

		ITask ContinueWith(Action<ITask<TResult>> action);
	}
}
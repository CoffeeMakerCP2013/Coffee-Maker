namespace EyeSoft.Threading.Tasks
{
	using System;

	public interface ITaskFactory
	{
		ITask StartNew(Action action);

		ITask<TResult> StartNew<TResult>(Func<TResult> func);
	}
}
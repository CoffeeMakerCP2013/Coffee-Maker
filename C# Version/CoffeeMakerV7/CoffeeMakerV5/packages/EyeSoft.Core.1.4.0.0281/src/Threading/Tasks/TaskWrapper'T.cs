namespace EyeSoft.Threading.Tasks
{
	using System;
	using System.Threading.Tasks;

	internal class TaskWrapper<TResult> : TaskWrapper, ITask<TResult>
	{
		private readonly Task<TResult> task;

		public TaskWrapper(Task<TResult> task)
			: base(task)
		{
			this.task = task;
		}

		public TResult Result
		{
			get { return task.Result; }
		}

		public ITask ContinueWith(Action<ITask<TResult>> action)
		{
			task.Wait();
			var continueWith = task.ContinueWith(t => action);

			return new TaskWrapper(continueWith);
		}
	}
}
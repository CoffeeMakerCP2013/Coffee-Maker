namespace EyeSoft.Threading.Tasks
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading;
	using System.Threading.Tasks;

	using EyeSoft.Extensions;

	internal class TaskWrapper : ITask
	{
		private readonly Task task;

		public TaskWrapper(Task task)
		{
			this.task = task;
		}

		public AggregateException Exception
		{
			get { return task.Exception; }
		}

		public bool IsFaulted
		{
			get { return task.IsFaulted; }
		}

		public bool IsCanceled
		{
			get { return task.IsCanceled; }
		}

		public bool IsCompleted
		{
			get { return task.IsCompleted; }
		}

		public WaitHandle AsyncWaitHandle
		{
			get { return task.Convert<IAsyncResult>().AsyncWaitHandle; }
		}

		public object AsyncState
		{
			get { return task.AsyncState; }
		}

		public bool CompletedSynchronously
		{
			get { return task.Convert<IAsyncResult>().CompletedSynchronously; }
		}

		public static void WaitAll(IEnumerable<ITask> tasks)
		{
			tasks
				.Cast<TaskWrapper>()
				.ToList()
				.ForEach(t => t.task.Wait());
		}

		public void Wait()
		{
			task.Wait();
		}

		public ITask ContinueWith(Action<ITask> action)
		{
			var continueWith = task.ContinueWith(t => action(this));
			return new TaskWrapper(continueWith);
		}

		public override string ToString()
		{
			return task.ToString();
		}

		public void Dispose()
		{
			task.Dispose();
		}
	}
}
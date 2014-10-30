namespace EyeSoft.Threading.Tasks
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	using EyeSoft.Logging;
	using EyeSoft.Messanging;

	internal class LocalTaskErrorWatcher
	{
		private readonly List<ITask> tasks = new List<ITask>();
		private readonly object syncLock = new object();

		public LocalTaskErrorWatcher()
		{
			Task.Factory.StartNew(Monitor);
		}

		public void AddTask(ITask task)
		{
			lock (syncLock)
			{
				tasks.Add(task);
			}
		}

		private void Monitor()
		{
			TaskUtility
				.Interval(3000, OnTaskFaultedSendException, LogException);
		}

		private void OnTaskFaultedSendException()
		{
			lock (syncLock)
			{
				for (var i = tasks.Count - 1; i >= 0; i--)
				{
					var task = tasks[i];

					if (task.IsFaulted)
					{
						MessageBroker
							.Send(new ExceptionMessage<ITask, AggregateException>(task, task.Exception));
					}

					if (task.IsCanceled || task.IsCompleted)
					{
						tasks.RemoveAt(i);
					}
				}
			}
		}

		private void LogException(Exception ex)
		{
			Logger.Error(ex);
		}
	}
}
namespace EyeSoft.Threading.Tasks
{
	using System;
	using System.Threading.Tasks;

	public class TaskFactoryWrapper : ITaskFactory
	{
		public ITask StartNew(Action action)
		{
			var task = new Task(action);
			var taskWrapper = new TaskWrapper(task);
			TaskErrorWatcher.AddTask(taskWrapper);
			task.Start();
			return taskWrapper;
		}

		public ITask<TResult> StartNew<TResult>(Func<TResult> func)
		{
			var task = new Task<TResult>(func);
			var taskWrapper = new TaskWrapper<TResult>(task);
			TaskErrorWatcher.AddTask(taskWrapper);
			task.Start();
			return taskWrapper;
		}
	}
}
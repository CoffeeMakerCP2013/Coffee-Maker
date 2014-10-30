namespace EyeSoft.Threading.Tasks
{
	public static class TaskErrorWatcher
	{
		private static readonly LocalTaskErrorWatcher instance = new LocalTaskErrorWatcher();

		public static void AddTask(ITask task)
		{
			instance.AddTask(task);
		}
	}
}
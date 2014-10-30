namespace EyeSoft.Threading.Tasks
{
	using System;
	using System.Diagnostics;
	using System.Threading;

	internal static class TaskUtility
	{
		public static void Interval(long interval, Action action, Action<Exception> errorHandler = null)
		{
			var watch = Stopwatch.StartNew();

			while (true)
			{
				try
				{
					action();
					watch.Stop();
					Thread.Sleep((int)Math.Max(0, interval - watch.ElapsedMilliseconds));
					watch.Restart();
				}
				catch (Exception ex)
				{
					if (errorHandler == null)
					{
						throw;
					}

					errorHandler(ex);
				}
			}
		}
	}
}
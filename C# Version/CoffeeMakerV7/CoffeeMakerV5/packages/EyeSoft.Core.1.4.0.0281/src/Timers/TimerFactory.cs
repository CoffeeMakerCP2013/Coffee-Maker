namespace EyeSoft.Timers
{
	using System;

	public static class TimerFactory
	{
		private static readonly Singleton<ITimerFactory> singletonInstance = new Singleton<ITimerFactory>(new DefaultTimerFactory());

		public static void Set(ITimerFactory instance)
		{
			singletonInstance.Set(instance);
		}

		public static ITimerFactory Create()
		{
			return singletonInstance.Instance;
		}

		public static ITimer Create(int interval, Action action)
		{
			return singletonInstance.Instance.Create(interval, action);
		}

		public static ITimer Start(int interval, Action action)
		{
			var timer = singletonInstance.Instance.Create(interval, action);

			timer.Start();

			return timer;
		}

		public static void DelayedAction(int interval, Action action)
		{
			singletonInstance.Instance.DelayedAction(interval, action);
		}
	}
}
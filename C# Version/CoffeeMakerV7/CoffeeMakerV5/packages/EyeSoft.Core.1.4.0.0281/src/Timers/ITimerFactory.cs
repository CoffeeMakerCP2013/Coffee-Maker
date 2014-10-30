namespace EyeSoft.Timers
{
	using System;

	public interface ITimerFactory
	{
		ITimer Create(int interval, Action action);

		void Create(int interval, Action<ITimer> action);

		void DelayedAction(int interval, Action action);
	}
}
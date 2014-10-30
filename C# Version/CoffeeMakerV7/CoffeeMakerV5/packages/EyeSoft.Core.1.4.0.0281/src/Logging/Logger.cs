namespace EyeSoft.Logging
{
	using System;
	using System.Collections.Generic;

	public static class Logger
	{
		private static readonly IList<ILogger> loggerList = new List<ILogger>();

		public static void Add(ILogger logger)
		{
			loggerList.Add(logger);
		}

		public static void Write(string message)
		{
			foreach (var logger in loggerList)
			{
				logger.Write(message);
			}
		}

		public static void Error(Exception exception)
		{
			var fullMessage = exception.FullMessage();
			Write(fullMessage);
		}
	}
}
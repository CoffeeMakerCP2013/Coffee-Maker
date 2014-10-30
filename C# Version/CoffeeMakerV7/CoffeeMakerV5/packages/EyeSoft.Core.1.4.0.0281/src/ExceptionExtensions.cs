namespace EyeSoft
{
	using System;
	using System.Diagnostics;
	using System.Reflection;
	using System.Text;

	public static class ExceptionExtensions
	{
		public static void Throw(this Exception exception)
		{
			exception.MantainOriginalStackTrace();
			throw exception;
		}

		public static string FullMessage(this Exception exception)
		{
			var stringBuilder = new StringBuilder();

			var currentException = exception;

			while (currentException != null)
			{
				stringBuilder.AppendLine(currentException.Message);

				currentException = currentException.InnerException;
			}

			var fullMessage = stringBuilder.ToString().TrimEnd(Environment.NewLine.ToCharArray());

			return fullMessage;
		}

		[DebuggerStepThrough]
		internal static void MantainOriginalStackTrace(this Exception exception)
		{
			typeof(Exception)
				.InvokeMember(
					"PrepForRemoting",
					BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod,
					null,
					exception,
					new object[0]);
		}
	}
}
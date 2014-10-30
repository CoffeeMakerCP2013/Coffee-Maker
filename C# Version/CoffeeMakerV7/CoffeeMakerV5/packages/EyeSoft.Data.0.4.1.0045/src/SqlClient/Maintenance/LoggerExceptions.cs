namespace EyeSoft.Data.SqlClient.Maintenance
{
	using System;
	using System.IO;

	public class LoggerExceptions
	{
		public static void WriteLog(string backupFolder, Exception exception)
		{
			var lines =
				new[]
					{
						"========================================================",
						string.Format("WriteLog error at {0}", DateTime.Now.FullTime()),
						exception.FullMessage()
					};

			File.AppendAllLines(Path.Combine(backupFolder, "Log.Exceptions.txt"), lines);
		}
	}
}
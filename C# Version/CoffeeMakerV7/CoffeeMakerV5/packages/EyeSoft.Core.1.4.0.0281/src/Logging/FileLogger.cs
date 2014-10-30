namespace EyeSoft.Logging
{
	using System.IO;

	public class FileLogger : ILogger
	{
		private readonly string file;

		public FileLogger(string file)
		{
			this.file = file;
		}

		public void Write(string message)
		{
			File.AppendAllText(file, message);
		}
	}
}
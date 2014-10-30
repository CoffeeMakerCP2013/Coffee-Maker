namespace EyeSoft.IO
{
	using System.IO;
	using System.Text;

	public static class StreamExtensions
	{
		public static string StreamToString(this Stream stream)
		{
			return stream.StreamToString(Encoding.Default);
		}

		public static string StreamToString(this Stream stream, Encoding encoding)
		{
			stream.Seek(0, SeekOrigin.Begin);
			var reader = new StreamReader(stream, encoding, true);
			return reader.ReadToEnd();
		}

		public static void SetSeekOnBegin(this Stream stream)
		{
			stream.Seek(0, SeekOrigin.Begin);
		}
	}
}
namespace EyeSoft.IO
{
	using System.IO;

	public interface IFileInfo
	{
		string FileName { get; }

		long Length { get; }

		string DirectoryName { get; }

		Stream OpenRead();

		Stream OpenWrite();
	}
}
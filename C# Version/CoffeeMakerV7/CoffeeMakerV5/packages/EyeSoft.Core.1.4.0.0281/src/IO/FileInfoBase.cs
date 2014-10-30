namespace EyeSoft.IO
{
	using System;
	using System.IO;

	public class FileInfoBase : IFileInfo
	{
		public FileInfoBase(string fileName, long length = 0)
		{
			Enforce.Argument(() => fileName);

			FileName = fileName;
			Length = length;
			DirectoryName = Path.GetDirectoryName(fileName);
		}

		public string FileName { get; private set; }

		public long Length { get; protected set; }

		public string DirectoryName { get; protected set; }

		public virtual Stream OpenRead()
		{
			throw new NotSupportedException();
		}

		public virtual Stream OpenWrite()
		{
			throw new NotSupportedException();
		}
	}
}
namespace EyeSoft.IO
{
	using System.IO;

	internal class FileInfoWrapper : FileInfoBase
	{
		private readonly FileInfo fileInfo;

		public FileInfoWrapper(string fileName)
		: base(fileName)
		{
			fileInfo = new FileInfo(fileName);
		}

		public override Stream OpenRead()
		{
			return fileInfo.OpenRead();
		}

		public override Stream OpenWrite()
		{
			return fileInfo.OpenWrite();
		}
	}
}
namespace EyeSoft.IO
{
	using System;
	using System.IO;
	using System.Security.AccessControl;

	internal class DirectoryInfoWrapper : IDirectoryInfo
	{
		private readonly DirectoryInfo directoryInfo;

		public DirectoryInfoWrapper(string path)
		{
			directoryInfo = new DirectoryInfo(path);
		}

		public FileAttributes Attributes
		{
			get { return directoryInfo.Attributes; }
			set { directoryInfo.Attributes = value; }
		}

		public DateTime CreationTime
		{
			get { return directoryInfo.CreationTime; }
			set { directoryInfo.CreationTime = value; }
		}

		public DateTime CreationTimeUtc
		{
			get { return directoryInfo.CreationTimeUtc; }
			set { directoryInfo.CreationTimeUtc = value; }
		}

		public bool Exists
		{
			get { return directoryInfo.Exists; }
		}

		public string FullName
		{
			get { return directoryInfo.FullName; }
		}

		public void Create()
		{
			directoryInfo.Create();
		}

		public void Create(DirectorySecurity directorySecurity)
		{
			directoryInfo.Create(directorySecurity);
		}

		public void Delete()
		{
			directoryInfo.Delete();
		}

		public void Delete(bool recursive)
		{
			directoryInfo.Delete(recursive);
		}

		public void DeleteIfExists(bool recursive)
		{
			if (!directoryInfo.Exists)
			{
				return;
			}

			directoryInfo.Delete(recursive);
		}

		public void DeleteSubFolders()
		{
			if (!directoryInfo.Exists)
			{
				return;
			}

			foreach (var subDirectory in directoryInfo.EnumerateDirectories())
			{
				subDirectory.Delete(true);
			}
		}
	}
}

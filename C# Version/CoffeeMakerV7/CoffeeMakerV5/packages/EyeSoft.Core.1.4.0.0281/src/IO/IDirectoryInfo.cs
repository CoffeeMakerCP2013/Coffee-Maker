namespace EyeSoft.IO
{
	using System;
	using System.IO;

	public interface IDirectoryInfo
	{
		FileAttributes Attributes { get; set; }

		DateTime CreationTime { get; set; }

		DateTime CreationTimeUtc { get; set; }

		string FullName { get; }

		bool Exists { get; }

		void Create();

		void Delete();

		void Delete(bool recursive);

		void DeleteIfExists(bool recursive);

		void DeleteSubFolders();
	}
}
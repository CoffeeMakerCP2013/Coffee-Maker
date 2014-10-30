namespace EyeSoft.IO
{
	using System.Collections.Generic;
	using System.IO;

	public interface IStorage
	{
		IFileInfo File(string path);

		IDirectoryInfo Directory(string path);

		void WriteAllBytes(string path, byte[] bytes);

		void WriteAllText(string path, string contents, bool overwrite = false);

		Stream OpenWrite(string path);

		Stream OpenRead(string path);

		IEnumerable<IFileInfo> GetFiles(string path, string searchPattern);

		string ReadAllText(string path);

		byte[] ReadAllBytes(string path);

		bool Exists(string path);

		void Delete(string path);

		string GetFileNameWithoutExtension(string path);
	}
}
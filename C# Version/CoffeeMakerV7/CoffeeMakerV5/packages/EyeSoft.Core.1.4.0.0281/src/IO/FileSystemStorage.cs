namespace EyeSoft.IO
{
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;

	public class FileSystemStorage : IStorage
	{
		public IFileInfo File(string path)
		{
			return new FileInfoWrapper(path);
		}

		public IDirectoryInfo Directory(string path)
		{
			return new DirectoryInfoWrapper(path);
		}

		public void WriteAllBytes(string path, byte[] bytes)
		{
			CheckParameterNotEmpty(path);

			System.IO.File.WriteAllBytes(path, bytes);
		}

		public void WriteAllText(string path, string contents, bool overwrite)
		{
			CheckParameterNotEmpty(path);

			if (overwrite)
			{
				System.IO.File.Delete(path);
			}

			System.IO.File.WriteAllText(path, contents);
		}

		public Stream OpenWrite(string path)
		{
			CheckParameterNotEmpty(path);

			return System.IO.File.OpenWrite(path);
		}

		public Stream OpenRead(string path)
		{
			CheckParameterNotEmpty(path);

			return System.IO.File.OpenRead(path);
		}

		public IEnumerable<IFileInfo> GetFiles(string path, string searchPattern)
		{
			CheckParameterNotEmpty(path);
			CheckParameterNotEmpty(searchPattern, "searchPattern");

			return
				new DirectoryInfo(path)
					.GetFiles(searchPattern)
					.Select(f => new FileInfoWrapper(f.FullName));
		}

		public string ReadAllText(string path)
		{
			CheckParameterNotEmpty(path);

			return System.IO.File.ReadAllText(path);
		}

		public byte[] ReadAllBytes(string path)
		{
			CheckParameterNotEmpty(path);

			return System.IO.File.ReadAllBytes(path);
		}

		public bool Exists(string path)
		{
			CheckParameterNotEmpty(path);

			return System.IO.File.Exists(path);
		}

		public void Delete(string path)
		{
			CheckParameterNotEmpty(path);

			System.IO.File.Delete(path);
		}

		public string GetFileNameWithoutExtension(string path)
		{
			CheckParameterNotEmpty(path);

			return Path.GetFileNameWithoutExtension(path);
		}

		private static void CheckParameterNotEmpty(string value, string parameterName = "path")
		{
			Ensure
				.That(value)
				.Named(parameterName)
				.Is.Not.NullOrWhiteSpace();
		}
	}
}
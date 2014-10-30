namespace EyeSoft.IO
{
	using System.Collections.Generic;
	using System.IO;

	public static class Storage
	{
		private static readonly Singleton<IStorage> singletonInstance = new Singleton<IStorage>(new FileSystemStorage());

		public static void Set(IStorage storage)
		{
			singletonInstance.Set(storage);
		}

		public static IFileInfo File(string path)
		{
			return singletonInstance.Instance.File(path);
		}

		public static IDirectoryInfo GetDirectoryInfo(string path)
		{
			return singletonInstance.Instance.Directory(path);
		}

		public static void WriteAllBytes(string path, byte[] bytes)
		{
			singletonInstance.Instance.WriteAllBytes(path, bytes);
		}

		public static void WriteAllText(string path, string contents, bool overwrite = false)
		{
			singletonInstance.Instance.WriteAllText(path, contents, overwrite);
		}

		public static Stream OpenWrite(string path)
		{
			return singletonInstance.Instance.OpenWrite(path);
		}

		public static Stream OpenRead(string path)
		{
			return singletonInstance.Instance.OpenRead(path);
		}

		public static IEnumerable<IFileInfo> GetFiles(string path, string searchPattern)
		{
			return singletonInstance.Instance.GetFiles(path, searchPattern);
		}

		public static string ReadAllText(string path)
		{
			return singletonInstance.Instance.ReadAllText(path);
		}

		public static byte[] ReadAllBytes(string path)
		{
			return singletonInstance.Instance.ReadAllBytes(path);
		}

		public static bool Exists(string path)
		{
			return singletonInstance.Instance.Exists(path);
		}

		public static void Delete(string path)
		{
			singletonInstance.Instance.Delete(path);
		}

		public static string GetFileNameWithoutExtension(string path)
		{
			return singletonInstance.Instance.GetFileNameWithoutExtension(path);
		}
	}
}
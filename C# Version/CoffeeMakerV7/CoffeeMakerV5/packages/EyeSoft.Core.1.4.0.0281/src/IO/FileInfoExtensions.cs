namespace EyeSoft.IO
{
	using System.Collections.Generic;
	using System.IO;

	using EyeSoft.Security.Cryptography;

	public static class FileInfoExtensions
	{
		public static IEnumerable<string> GetLines(this IFileInfo fileInfo)
		{
			using (var stream = fileInfo.OpenRead())
			{
				using (var streamReader = new StreamReader(stream))
				{
					var nextLine = streamReader.ReadLine();

					while (nextLine != null)
					{
						yield return nextLine;
						nextLine = streamReader.ReadLine();
					}
				}
			}
		}

		public static string Hash(this IFileInfo fileInfo, IHashAlgorithm hashAlgorithm = null)
		{
			if (hashAlgorithm == null)
			{
				hashAlgorithm = HashAlgorithmFactory.Sha1;
			}

			using (hashAlgorithm)
			{
				using (var stream = fileInfo.OpenRead())
				{
					var hash = hashAlgorithm.ComputeHashString(stream);

					return hash;
				}
			}
		}
	}
}
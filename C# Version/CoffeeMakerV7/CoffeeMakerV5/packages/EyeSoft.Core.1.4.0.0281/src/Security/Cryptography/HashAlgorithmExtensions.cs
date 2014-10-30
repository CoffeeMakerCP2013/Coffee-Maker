namespace EyeSoft.Security.Cryptography
{
	using System.IO;
	using System.Text;

	public static class HashAlgorithmExtensions
	{
		public static byte[] ComputeHash(this IHashAlgorithm hashAlgorithm, string value)
		{
			using (var stream = new MemoryStream(value.ToByteArray()))
			{
				var hash = hashAlgorithm.ComputeHash(stream);

				return hash;
			}
		}

		public static string ComputeHashString(this IHashAlgorithm hashAlgorithm, string value)
		{
			return
				hashAlgorithm.ComputeHash(value).ComputeHex();
		}

		public static string ComputeHex(this IHashAlgorithm hashAlgorithm, string value)
		{
			var hash = hashAlgorithm.ComputeHash(value);

			return hash.ComputeHex();
		}

		public static string ComputeHexWithEncoding(this IHashAlgorithm hashAlgorithm, string value)
		{
			var hash = hashAlgorithm.ComputeHash(Encoding.Default.GetBytes(value));

			return hash.ComputeHex();
		}

		public static string ComputeHashString(this IHashAlgorithm hashAlgorithm, Stream stream)
		{
			var hash = hashAlgorithm.ComputeHash(stream);

			return ComputeHex(hash);
		}

		public static string ComputeHex(this byte[] hash)
		{
			var stringBuilder = new StringBuilder(40);

			foreach (var element in hash)
			{
				stringBuilder.Append(element.ToString("x2"));
			}

			return stringBuilder.ToString().ToLower();
		}
	}
}
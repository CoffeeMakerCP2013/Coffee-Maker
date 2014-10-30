namespace EyeSoft.Security.Cryptography
{
	using System.IO;
	using System.Security.Cryptography;
	using System.Text;

	using EyeSoft.Extensions;
	using EyeSoft.IO;

	public static class Sha1Extensions
	{
		public static string ComputeSha1(this Stream stream)
		{
			Enforce
				.Argument(() => stream);

			if (stream.Position != 0)
			{
				throw new EndOfStreamException("The stream must be at the beginning to calculate the SHA1.");
			}

			var sha1 =
				Create(HashAlgorithms.Sha1)
					.ComputeHash(stream)
					.ComputeHex();

			stream.SetSeekOnBegin();

			return
				sha1;
		}

		public static string ComputeSha1(this byte[] buffer)
		{
			Enforce
				.Argument(() => buffer);

			var sha1 =
				Create(HashAlgorithms.Sha1)
					.ComputeHash(buffer)
					.ComputeHex();

			return
				sha1;
		}

		public static string ComputeSha1(this string value)
		{
			Enforce.Argument(() => value);

			return
				new MemoryStream(Encoding.UTF8.GetBytes(value))
					.Using(
						stream =>
							{
								var sha1 =
									Create(HashAlgorithms.Sha1)
										.ComputeHash(stream)
										.ComputeHex();

								return sha1;
							});
		}

		private static HashAlgorithm Create(string hashName)
		{
			var hashAlgorithm =
				HashAlgorithm.Create(hashName);

			Ensure
				.That(hashAlgorithm)
				.Is.Not.Null();

			return hashAlgorithm;
		}
	}
}
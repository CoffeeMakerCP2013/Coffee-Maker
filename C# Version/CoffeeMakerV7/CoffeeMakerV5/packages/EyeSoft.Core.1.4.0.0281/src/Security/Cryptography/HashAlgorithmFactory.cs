namespace EyeSoft.Security.Cryptography
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Security.Cryptography;

	public static class HashAlgorithmFactory
	{
		private static readonly IDictionary<string, Func<HashAlgorithmWrapper>> hashAlgorithmDictionary =
			new Dictionary<string, Func<HashAlgorithmWrapper>>();

		private static readonly IDictionary<string, Type> hashAlgorithmTypeDictionary =
			new Dictionary<string, Type>
				{
					{ HashAlgorithms.Md5, typeof(MD5) },
					{ HashAlgorithms.Sha1, typeof(SHA1) },
					{ HashAlgorithms.Sha256, typeof(SHA256) },
					{ HashAlgorithms.Sha384, typeof(SHA384) },
					{ HashAlgorithms.Sha512, typeof(SHA512) },
					{ HashAlgorithms.Ripemd160, typeof(RIPEMD160) },
				};

		private static IHashAlgorithmFactory hashAlgorithmFactory =
			new HashAlgorithmFactoryWrapper();

		public static IHashAlgorithm Md5
		{
			get { return Create(HashAlgorithms.Md5); }
		}

		public static IHashAlgorithm Sha1
		{
			get { return Create(HashAlgorithms.Sha1); }
		}

		public static IHashAlgorithm Sha256
		{
			get { return Create(HashAlgorithms.Sha256); }
		}

		public static IHashAlgorithm Sha384
		{
			get { return Create(HashAlgorithms.Sha384); }
		}

		public static IHashAlgorithm Sha512
		{
			get { return Create(HashAlgorithms.Sha512); }
		}

		public static IHashAlgorithm Ripemd160
		{
			get { return Create(HashAlgorithms.Ripemd160); }
		}

		public static void SetHashAlgorithmFactory(IHashAlgorithmFactory hashAlgorithmFactory)
		{
			Enforce
				.Argument(() => hashAlgorithmFactory);

			HashAlgorithmFactory.hashAlgorithmFactory = hashAlgorithmFactory;
		}

		public static IHashAlgorithm Create(string providerName)
		{
			Enforce.Argument(() => providerName);

			Ensure
				.That(hashAlgorithmFactory)
				.Is.Not.Null();

			if (hashAlgorithmDictionary.ContainsKey(providerName))
			{
				return
					hashAlgorithmDictionary[providerName]();
			}

			return
				hashAlgorithmFactory.Create(providerName);
		}

		public static void Register<T>(string providerName)
			where T : HashAlgorithm, new()
		{
			if (HashAlgorithms.All.Any(p => p.Equals(providerName, StringComparison.InvariantCultureIgnoreCase)))
			{
				var message =
					"The provider name is a system hash algorithm and cannot be used. Provider name: {ProviderName}"
						.NamedFormat(providerName);

				new ArgumentException(message)
					.Throw();
			}

			var providerByType =
				hashAlgorithmTypeDictionary.SingleOrDefault(p => p.Value == typeof(T));

			if (providerByType.Key != null)
			{
				var message =
					"The hash algorithm is already registered with the name {ProviderName}."
						.NamedFormat(providerByType.Key);

				new ArgumentException(message)
					.Throw();
			}

			hashAlgorithmDictionary
				.Add(providerName, () => new HashAlgorithmWrapper(new T()));

			hashAlgorithmTypeDictionary
				.Add(providerName, typeof(T));
		}

		public static void Register<T>()
			where T : HashAlgorithm, new()
		{
			var providerName = typeof(T).Name.Replace(typeof(HashAlgorithm).Name, null);

			Register<T>(providerName);
		}

		public static void ClearCustomProviders()
		{
			hashAlgorithmDictionary.Clear();
			hashAlgorithmTypeDictionary.Clear();
		}
	}
}
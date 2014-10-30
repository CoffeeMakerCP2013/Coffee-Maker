namespace EyeSoft
{
	using System;
	using System.IO;
	using System.Reflection;

	public static class AssemblyExtensions
	{
		public static Stream GetResourceStream(this Type type, string resourceKey, bool isFullName = false)
		{
			Enforce
				.Argument(() => type)
				.Argument(() => resourceKey);

			return type.Assembly.GetResourceStream(resourceKey, isFullName);
		}

		public static string ReadResourceText(this Type type, string resourceKey, bool isFullName = false)
		{
			Enforce
				.Argument(() => type)
				.Argument(() => resourceKey);

			return type.Assembly.ReadResourceText(resourceKey, isFullName);
		}

		public static string ReadResourceText(this Assembly assembly, string resourceKey, bool isFullName = false)
		{
			using (var stream = assembly.GetResourceStream(resourceKey, isFullName))
			{
				using (var reader = new StreamReader(stream))
				{
					return reader.ReadToEnd();
				}
			}
		}

		public static Stream GetResourceStream(this Assembly assembly, string resourceKey, bool isFullName = false)
		{
			Enforce
				.Argument(() => assembly)
				.Argument(() => resourceKey);

			var key =
				isFullName ?
					resourceKey :
					string.Concat(assembly.GetName().Name, ".", resourceKey);

			return assembly.GetManifestResourceStream(key);
		}
	}
}
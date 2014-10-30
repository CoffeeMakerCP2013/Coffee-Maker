namespace EyeSoft.Reflection
{
	using System;
	using System.IO;
	using System.Reflection;

	public static class AssemblyExtensions
	{
		public static string ReadResource(this Assembly assembly, string resourceName, bool addNamespaceBasedOnAssemblyName = true)
		{
			var localResourceName =
				addNamespaceBasedOnAssemblyName ?
				string.Format("{0}.{1}", assembly.GetName().Name, resourceName) :
				resourceName;

			using (var stream = assembly.GetManifestResourceStream(localResourceName))
			{
				Ensure
					.That(stream)
					.WithException(new ArgumentException("Cannot find a resources with the specified name."))
					.Is.Not.Null();

				using (var reader = new StreamReader(stream))
				{
					return reader.ReadToEnd();
				}
			}
		}
	}
}
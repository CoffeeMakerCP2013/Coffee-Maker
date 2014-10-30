namespace EyeSoft.Serialization
{
	using System.IO;

	public static class SerializerExtensions
	{
		public static Stream SerializeToStream<T>(this ISerializer<T> serializer, T obj)
		{
			return serializer.SerializeToStream(obj, new MemoryStream());
		}
	}
}
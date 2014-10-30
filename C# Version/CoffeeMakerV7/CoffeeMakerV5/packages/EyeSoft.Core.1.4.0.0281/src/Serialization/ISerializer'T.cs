namespace EyeSoft.Serialization
{
	using System.Collections.Generic;
	using System.IO;

	public interface ISerializer<T>
	{
		string Serialize(T obj);

		Stream SerializeToStream(T obj);

		Stream SerializeToStream(T obj, Stream stream);

		Stream SerializeToStream(IEnumerable<T> collection);

		string Serialize(IEnumerable<T> collection);

		T Deserialize(string text);

		T Deserialize(Stream stream);

		IEnumerable<T> DeserializeCollection(Stream stream);

		IEnumerable<T> DeserializeCollection(string text);
	}
}
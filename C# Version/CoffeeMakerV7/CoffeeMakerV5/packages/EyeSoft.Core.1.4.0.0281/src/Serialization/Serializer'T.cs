namespace EyeSoft.Serialization
{
	using System.Collections.Generic;
	using System.IO;

	using EyeSoft.IO;

	public abstract class Serializer<T> : ISerializer<T>
	{
		public abstract string Serialize(T obj);

		public abstract Stream SerializeToStream(T obj, Stream stream);

		public abstract string Serialize(IEnumerable<T> collection);

		public abstract T Deserialize(string text);

		public abstract IEnumerable<T> DeserializeCollection(string text);

		public IEnumerable<T> DeserializeCollection(Stream stream)
		{
			return DeserializeCollection(stream.ToString());
		}

		public virtual Stream SerializeToStream(IEnumerable<T> collection)
		{
			return Serialize(collection).ToStream();
		}

		public virtual Stream SerializeToStream(T obj)
		{
			return SerializerExtensions.SerializeToStream(this, obj);
		}

		public virtual T Deserialize(Stream stream)
		{
			return Deserialize(stream.StreamToString());
		}
	}
}

namespace EyeSoft.Xml.Serialization
{
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Xml;
	using System.Xml.Linq;

	using EyeSoft.Extensions;
	using EyeSoft.Serialization;

	public class XmlSerializer<T> : Serializer<T>
	{
		private readonly FormattedXmlSerializer serializer = new FormattedXmlSerializer(typeof(T));

		public override string Serialize(T obj)
		{
			return serializer.Serialize(obj);
		}

		public override Stream SerializeToStream(T obj, Stream stream)
		{
			return serializer.SerializeToStream(obj, stream);
		}

		public override T Deserialize(string xml)
		{
			using (var stringReader = new StringReader(xml))
			{
				using (var xmlReader = XmlReader.Create(stringReader))
				{
					return serializer.Deserialize(xmlReader).Convert<T>();
				}
			}
		}

		public override T Deserialize(Stream stream)
		{
			var deserialize = (T)serializer.Deserialize(stream);

			return deserialize;
		}

		public override string Serialize(IEnumerable<T> collection)
		{
			var list = collection.ToList();

			var listType = list.GetType();

			var collectionSerializer = new FormattedXmlSerializer(listType);

			var collectionSerialized = collectionSerializer.Serialize(list);

			var typeName = list.AsQueryable().ElementType.Name;
			var collectionName = string.Format("ArrayOf{0}", typeName);
			var newCollectionName = string.Format("{0}List", typeName);

			collectionSerialized = collectionSerialized.Replace(collectionName, newCollectionName);

			return collectionSerialized;
		}

		public override IEnumerable<T> DeserializeCollection(string xml)
		{
			var nodes = XElement.Parse(xml).Nodes().Select(element => element.ToString()).ToList();

			var deserializeCollection = nodes.Select(Deserialize).ToList();

			return deserializeCollection;
		}
	}
}
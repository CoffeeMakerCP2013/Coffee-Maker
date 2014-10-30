namespace EyeSoft.Collections.Generic
{
	using System.Collections.Generic;

	using EyeSoft.Extensions;

	public static class CollectionExtensions
	{
		public static ICollection<T> AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
		{
			Enforce
				.Argument(() => collection)
				.Argument(() => items);

			var list = collection as List<T>;

			if (list.IsNotNull())
			{
				list.AddRange(items);
				return list;
			}

			foreach (var item in items)
			{
				collection.Add(item);
			}

			return collection;
		}
	}
}
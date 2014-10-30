namespace EyeSoft.Mapping
{
	using System;

	public static class Mapper
	{
		private static readonly Singleton<IMapper> singletonInstance = new Singleton<IMapper>();

		public static void Set(IMapper mapper)
		{
			singletonInstance.Set(mapper);
		}

		public static object Map(object source, Type sourceType, Type destinationType)
		{
			return singletonInstance.Instance.Map(source, sourceType, destinationType);
		}

		public static TDestination Map<TDestination>(object source)
		{
			return singletonInstance.Instance.Map<TDestination>(source);
		}

		public static TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
		{
			return singletonInstance.Instance.Map(source, destination);
		}
	}
}
namespace EyeSoft.Mapping
{

	using EyeSoft.Conventions;
	using EyeSoft.Mapping.Conventions;

	public static class TypeMapperFactory
	{
		public static TypeMapper Create(TypeMapperConventions typeMapperConventions)
		{
			return
				new TypeMapper(typeMapperConventions);
		}

		public static TypeMapper Crate(TypeMapperConventions typeMapperConventions)
		{
			return
				new TypeMapper(typeMapperConventions);
		}

		public static TypeMapper Create()
		{
			var typeMapperConventions =
				new TypeMapperConventions(
					new KeyConvention(),
					new VersionConvention());

			return
				new TypeMapper(typeMapperConventions);
		}

		public static TypeMapper CreateByConventions()
		{
			return
				CreateByConventions(new MetadataConvention(), new KeyConvention(), new VersionConvention());
		}

		public static TypeMapper CreateByConventions(
			TypeConvention<object, object> convention,
			IKeyConvention keyConvention,
			IVersionConvention versionConvention)
		{
			var typeMapperConventions =
				new TypeMapperConventions(
					convention,
					keyConvention,
					versionConvention);

			return
				new TypeMapper(typeMapperConventions);
		}
	}
}
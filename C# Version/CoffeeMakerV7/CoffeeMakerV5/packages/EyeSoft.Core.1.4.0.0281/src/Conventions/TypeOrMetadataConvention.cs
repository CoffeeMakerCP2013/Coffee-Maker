namespace EyeSoft.Conventions
{
	using System;
	using System.ComponentModel.DataAnnotations;

	using EyeSoft.Extensions;
	using EyeSoft.Reflection;

	public class TypeOrMetadataConvention
		: TypeConvention<object, object>
	{
		protected override Type TryMapTo(Type type)
		{
			var metadataTypeAttribute =
				type.GetAttribute<MetadataTypeAttribute>();

			return
				metadataTypeAttribute.IsNull() ?
					type :
					metadataTypeAttribute.MetadataClassType;
		}
	}
}
using Connected.Annotations.Entities;
using Connected.Membership.Claims;
using System.Collections.Immutable;

namespace Connected.Customers.Service.Desks.Schema;

internal sealed class DeskSchemaProvider(IDeskService desks) : ClaimSchemaProvider
{
	protected override async Task<IImmutableList<IClaimSchema>> OnInvoke()
	{
		var result = new List<IClaimSchema>();

		if (Dto.Entity is null)
			result.Add(new ClaimSchema { Entity = SchemaAttribute.CustomersSchema, EntityId = SchemaAttribute.CustomersSchema, Text = Strings.CustomersDomain });
		else if (string.Equals(Dto.Entity, SchemaAttribute.CustomersSchema, StringComparison.OrdinalIgnoreCase))
			result.Add(new ClaimSchema { Entity = AuthorizationMetaData.DesksKey, EntityId = SchemaAttribute.CustomersSchema, Text = SR.Desks });
		else if (string.Equals(Dto.Entity, AuthorizationMetaData.DesksKey, StringComparison.OrdinalIgnoreCase))
		{
			var items = await desks.Query(null);

			foreach (var item in items)
				result.Add(new ClaimSchema { Entity = item.Id.ToString(), EntityId = ServiceMetaData.DeskKey, Text = item.Name });
		}

		return result.ToImmutableList();
	}
}

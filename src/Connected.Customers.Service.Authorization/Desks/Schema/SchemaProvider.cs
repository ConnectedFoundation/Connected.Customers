using Connected.Annotations.Entities;
using Connected.Membership.Claims;
using System.Collections.Immutable;

namespace Connected.Customers.Service.Desks.Schema;

internal sealed class DeskSchemaProvider(IDeskService desks) : ClaimSchemaProvider
{
	protected override async Task<IImmutableList<IClaimSchema>> OnInvoke()
	{
		var result = new List<IClaimSchema>();

		if (Dto.Id is null)
			result.Add(new ClaimSchema { Id = SchemaAttribute.CustomersSchema, Type = SchemaAttribute.CustomersSchema, Text = Strings.CustomersDomain });
		else if (string.Equals(Dto.Id, SchemaAttribute.CustomersSchema, StringComparison.OrdinalIgnoreCase))
			result.Add(new ClaimSchema { Id = AuthorizationMetaData.DesksKey, Type = SchemaAttribute.CustomersSchema, Text = SR.Desks });
		else if (string.Equals(Dto.Id, AuthorizationMetaData.DesksKey, StringComparison.OrdinalIgnoreCase))
		{
			var items = await desks.Query(null);

			foreach (var item in items)
				result.Add(new ClaimSchema { Id = item.Id.ToString(), Type = ServiceMetaData.DeskKey, Text = item.Name });
		}

		return result.ToImmutableList();
	}
}

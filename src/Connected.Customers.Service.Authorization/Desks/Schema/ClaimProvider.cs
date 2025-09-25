using Connected.Annotations.Entities;
using Connected.Membership.Claims;
using System.Collections.Immutable;

namespace Connected.Customers.Service.Desks.Schema;

internal sealed class ClaimProvider : ClaimDescriptorProvider
{
	protected override async Task<IImmutableList<IClaimDescriptor>> OnInvoke()
	{
		var result = new List<IClaimDescriptor>();

		if (string.Equals(Dto.EntityId, AuthorizationMetaData.DesksKey, StringComparison.OrdinalIgnoreCase)
			&& string.Equals(Dto.Entity, SchemaAttribute.CustomersSchema, StringComparison.OrdinalIgnoreCase))
		{
			result.Add(new ClaimDescriptor { Entity = SchemaAttribute.CustomersSchema, EntityId = AuthorizationMetaData.DesksKey, Value = DeskClaims.InsertDesk });
		}
		else if (string.Equals(Dto.Entity, AuthorizationMetaData.DesksKey, StringComparison.OrdinalIgnoreCase))
		{
			result.Add(new ClaimDescriptor { Entity = AuthorizationMetaData.DesksKey, EntityId = ServiceMetaData.DeskKey, Value = DeskClaims.DeskSecurity, Text = DeskClaims.UpdateDesk });
			result.Add(new ClaimDescriptor { Entity = AuthorizationMetaData.DesksKey, EntityId = ServiceMetaData.DeskKey, Value = DeskClaims.DeleteDesk, Text = DeskClaims.DeleteDesk });
			result.Add(new ClaimDescriptor { Entity = AuthorizationMetaData.DesksKey, EntityId = ServiceMetaData.DeskKey, Value = DeskClaims.DeskSecurity, Text = DeskClaims.DeskSecurity });
			result.Add(new ClaimDescriptor { Entity = AuthorizationMetaData.DesksKey, EntityId = ServiceMetaData.DeskKey, Value = DeskClaims.ModerateTickets, Text = DeskClaims.ModerateTickets });
		}

		return await Task.FromResult(result.ToImmutableList());
	}
}

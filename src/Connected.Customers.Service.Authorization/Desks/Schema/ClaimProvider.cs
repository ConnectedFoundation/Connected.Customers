using Connected.Annotations.Entities;
using Connected.Membership.Claims;
using System.Collections.Immutable;

namespace Connected.Customers.Service.Desks.Schema;

internal sealed class ClaimProvider : ClaimDescriptorProvider
{
	protected override async Task<IImmutableList<IClaimDescriptor>> OnInvoke()
	{
		var result = new List<IClaimDescriptor>();

		if (string.Equals(Dto.Id, AuthorizationMetaData.DesksKey, StringComparison.OrdinalIgnoreCase)
			&& string.Equals(Dto.Type, SchemaAttribute.CustomersSchema, StringComparison.OrdinalIgnoreCase))
		{
			result.Add(new ClaimDescriptor { Id = DeskClaims.InsertDesk, Text = DeskClaims.InsertDesk });
		}
		else if (string.Equals(Dto.Type, ServiceMetaData.DeskKey, StringComparison.OrdinalIgnoreCase))
		{
			result.Add(new ClaimDescriptor { Id = DeskClaims.UpdateDesk, Text = DeskClaims.UpdateDesk });
			result.Add(new ClaimDescriptor { Id = DeskClaims.DeleteDesk, Text = DeskClaims.DeleteDesk });
			result.Add(new ClaimDescriptor { Id = DeskClaims.DeskSecurity, Text = DeskClaims.DeskSecurity });
			result.Add(new ClaimDescriptor { Id = DeskClaims.ModerateTickets, Text = DeskClaims.ModerateTickets });
		}

		return await Task.FromResult(result.ToImmutableList());
	}
}

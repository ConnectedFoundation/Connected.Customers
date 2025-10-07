using Connected.Annotations.Entities;
using Connected.Membership.Claims;

namespace Connected.Customers.Service.Desks.Schema;

internal sealed class ClaimProvider : ClaimDescriptorProvider
{
	protected override async Task OnInvoke()
	{
		if (DtoEquals(SchemaAttribute.CustomersSchema, AuthorizationMetaData.DesksKey))
			Add(SchemaAttribute.CustomersSchema, AuthorizationMetaData.DesksKey, null, DeskClaims.InsertDesk);
		else if (DtoEquals(Dto.Entity, AuthorizationMetaData.DesksKey))
		{
			Add(AuthorizationMetaData.DesksKey, ServiceMetaData.DeskKey, DeskClaims.UpdateDesk, DeskClaims.DeskSecurity);
			Add(AuthorizationMetaData.DesksKey, ServiceMetaData.DeskKey, DeskClaims.DeleteDesk, DeskClaims.DeleteDesk);
			Add(AuthorizationMetaData.DesksKey, ServiceMetaData.DeskKey, DeskClaims.DeskSecurity, DeskClaims.DeskSecurity);
			Add(AuthorizationMetaData.DesksKey, ServiceMetaData.DeskKey, DeskClaims.ModerateTickets, DeskClaims.ModerateTickets);
		}

		await Task.CompletedTask;
	}
}

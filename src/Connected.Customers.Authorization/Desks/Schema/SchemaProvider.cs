using Connected.Annotations.Entities;
using Connected.Customers.Authorization;
using Connected.Customers.Desks;
using Connected.Membership.Claims;

namespace Connected.Customers.Authorization.Desks.Schema;

internal sealed class DeskSchemaProvider(IDeskService desks) : ClaimSchemaProvider
{
	protected override async Task OnInvoke()
	{
		if (Dto.Entity is null)
			Add(SchemaAttribute.CustomersSchema, SchemaAttribute.CustomersSchema, Strings.CustomersDomain);
		else if (DtoEquals(SchemaAttribute.CustomersSchema))
			Add(AuthorizationMetaData.DesksKey, SchemaAttribute.CustomersSchema, SR.Desks);
		else if (DtoEquals(Dto.Entity, AuthorizationMetaData.DesksKey))
		{
			var items = await desks.Query(null);

			foreach (var item in items)
				Add(item.Id.ToString(), ServiceMetaData.DeskKey, item.Name);
		}
	}
}

using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Authorization.Services;
using Connected.Customers.Desks;
using Connected.Customers.Desks.Dtos;
using Connected.Membership.Annotations;

namespace Connected.Customers.Authorization.Desks;

[Middleware<IDeskService>(nameof(IDeskService.Insert))]
[Claims(DeskClaims.InsertDesk)]
internal sealed class Insert
	: BoundServiceOperationAuthorization<IInsertDeskDto>
{
	public override string Entity => SchemaAttribute.CustomersSchema;
	public override string EntityId => NullAuthorizationEntityId;
}

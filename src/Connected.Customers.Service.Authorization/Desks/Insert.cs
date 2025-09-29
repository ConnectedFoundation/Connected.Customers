using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Authorization.Services;
using Connected.Customers.Service.Desks.Dtos;
using Connected.Membership.Annotations;

namespace Connected.Customers.Service.Desks;

[Middleware<IDeskService>(nameof(IDeskService.Insert))]
[Claims(DeskClaims.InsertDesk)]
internal sealed class Insert
	: BoundServiceOperationAuthorization<IInsertDeskDto>
{
	public override string Entity => SchemaAttribute.CustomersSchema;
	public override string EntityId => NullAuthorizationEntityId;
}

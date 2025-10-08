using Connected.Annotations;
using Connected.Authorization.Services;
using Connected.Customers.Desks;
using Connected.Membership.Annotations;
using Connected.Services;

namespace Connected.Customers.Authorization.Desks;

[Middleware<IDeskService>(nameof(IDeskService.Delete))]
[Claims(DeskClaims.DeleteDesk)]
internal sealed class Delete
	: BoundServiceOperationAuthorization<IPrimaryKeyDto<int>>
{
	public override string Entity => ServiceMetaData.DeskKey;
	public override string EntityId => Dto.Id.ToString();
}

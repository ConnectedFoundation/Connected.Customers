using Connected.Annotations;
using Connected.Authorization.Services;
using Connected.Membership.Annotations;
using Connected.Services;

namespace Connected.Customers.Service.Desks;

[Middleware<IDeskService>(nameof(IDeskService.Delete))]
[Claims(DeskClaims.DeleteDesk)]
internal sealed class Delete
	: ServiceOperationAuthorization<IPrimaryKeyDto<int>>
{
	public override string Entity => ServiceMetaData.DeskKey;
	public override string EntityId => Dto.Id.ToString();
}

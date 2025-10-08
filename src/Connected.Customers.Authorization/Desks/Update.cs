using Connected.Annotations;
using Connected.Authorization.Services;
using Connected.Customers.Desks;
using Connected.Customers.Desks.Dtos;
using Connected.Membership.Annotations;

namespace Connected.Customers.Authorization.Desks;

[Middleware<IDeskService>(nameof(IDeskService.Update))]
[Claims(DeskClaims.UpdateDesk)]
internal sealed class Update
	: BoundServiceOperationAuthorization<IUpdateDeskDto>
{
	public override string Entity => ServiceMetaData.DeskKey;
	public override string EntityId => Dto.Id.ToString();
}

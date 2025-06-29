using Connected.Annotations;
using Connected.Authorization.Services;
using Connected.Customers.Service.Desks.Dtos;
using Connected.Membership.Annotations;

namespace Connected.Customers.Service.Desks;

[Middleware<IDeskService>(nameof(IDeskService.Update))]
[Claims(DeskClaims.UpdateDesk)]
internal sealed class Update
	: ServiceOperationAuthorization<IUpdateDeskDto>
{
	public override string? Type => ServiceMetaData.DeskKey;
	public override string? PrimaryKey => Dto?.Id.ToString();
}

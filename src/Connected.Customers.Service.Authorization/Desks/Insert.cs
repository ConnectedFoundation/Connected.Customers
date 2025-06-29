using Connected.Annotations;
using Connected.Authorization.Services;
using Connected.Customers.Service.Desks.Dtos;
using Connected.Membership.Annotations;

namespace Connected.Customers.Service.Desks;

[Middleware<IDeskService>(nameof(IDeskService.Insert))]
[Claims(DeskClaims.InsertDesk)]
internal sealed class Insert
	: ServiceOperationAuthorization<IInsertDeskDto>
{
}

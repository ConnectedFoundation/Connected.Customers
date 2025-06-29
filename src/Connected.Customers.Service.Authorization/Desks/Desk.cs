using Connected.Authorization.Entities;
using Connected.Membership.Annotations;

namespace Connected.Customers.Service.Desks;

[Claims(DeskClaims.ReadDesk)]
internal sealed class Desk : EntityAuthorization<IDesk>
{
	public override string? Type => ServiceMetaData.DeskKey;
	public override string? PrimaryKey => Entity.Id.ToString();
}

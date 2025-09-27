using Connected.Authorization.Entities;
using Connected.Entities;
using Connected.Membership.Annotations;

namespace Connected.Customers.Service.Desks;

[Claims(DeskClaims.ReadDesk)]
internal sealed class Desk : EntityAuthorization<IDesk>
{
	public override string Entity => typeof(IDesk).EntityKey();
	public override string EntityId => Instance.Id.ToString();
}

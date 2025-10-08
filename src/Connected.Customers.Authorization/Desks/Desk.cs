using Connected.Authorization.Entities;
using Connected.Customers.Desks;
using Connected.Entities;
using Connected.Membership.Annotations;

namespace Connected.Customers.Authorization.Desks;

[Claims(DeskClaims.ReadDesk)]
internal sealed class Desk : EntityAuthorization<IDesk>
{
	public override string Entity => typeof(IDesk).EntityKey();
	public override string EntityId => Instance.Id.ToString();
}

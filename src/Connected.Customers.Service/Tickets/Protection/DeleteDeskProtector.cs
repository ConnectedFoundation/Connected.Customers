using Connected.Customers.Service.Desks;
using Connected.Entities.Protection;
using Connected.Services;

namespace Connected.Customers.Service.Tickets.Protection;

internal sealed class DeleteDeskProtector(ITicketService tickets) : EntityProtector<IDesk>
{
	protected override async Task OnInvoke()
	{
		if (State != Entities.State.Delete)
			return;

		var items = await tickets.Query(Dto.Factory.CreateHead(Entity.Id));

		if (items.Any())
			throw new InvalidOperationException($"{Strings.ErrEntityProtection} ({nameof(DeleteDeskProtector)})");
	}
}

using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Customers.Service.Tickets.Ops;

internal sealed class Delete(IStorageProvider storage, ITicketService tickets, IEventService events, ITicketCache cache)
  : ServiceAction<IPrimaryKeyDto<int>>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await tickets.Select(Dto)) as Ticket ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<Ticket>().Update(entity.Merge(Dto, State.Delete));
		await cache.Remove(Dto.Id);
		await events.Deleted(this, tickets, entity.Id);
	}
}

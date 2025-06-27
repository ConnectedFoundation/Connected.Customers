using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Customers.Service.Tickets.Ops;

internal sealed class Delete(IStorageProvider storage, ITicketService tickets, IEventService events, ITicketCache cache)
  : ServiceAction<IDependentPrimaryKeyDto<int, int>>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await tickets.Select(Dto)) as Ticket ?? throw new NullReferenceException(Strings.ErrEntityExpected);
		var key = Dto.GenerateKey();

		await storage.Open<Ticket>().Update(entity.Merge(Dto, State.Delete));
		await cache.Remove(key);
		await events.Deleted(this, tickets, key);
	}
}

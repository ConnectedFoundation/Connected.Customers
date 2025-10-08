using Connected.Customers.Tickets.Dtos;
using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Customers.Tickets.Ops;

internal sealed class Update(IStorageProvider storage, ITicketService tickets, IEventService events, ITicketCache cache)
  : ServiceAction<IUpdateTicketDto>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await tickets.Select(Dto)) as Ticket ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<Ticket>().Update(entity.Merge(Dto, State.Update), Dto, async () =>
		{
			await cache.Remove(Dto.DistributedKey());

			return await tickets.Select(Dto) as Ticket ?? throw new NullReferenceException(Strings.ErrEntityExpected);
		}, Caller);

		await cache.Remove(Dto.DistributedKey());
		await events.Updated(this, tickets, Dto.DistributedKey());
	}
}

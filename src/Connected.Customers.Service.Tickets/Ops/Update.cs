using Connected.Customers.Service.Tickets.Dtos;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Customers.Service.Tickets.Ops;

internal sealed class Update(IStorageProvider storage, ITicketService tickets, IEventService events, ITicketCache cache)
  : ServiceAction<IUpdateTicketDto>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await tickets.Select(Dto)) as Ticket ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<Ticket>().Update(entity.Merge(Dto, Entities.State.Update), Dto, async () =>
		{
			await cache.Remove(Dto.Id);

			return await tickets.Select(Dto) as Ticket ?? throw new NullReferenceException(Strings.ErrEntityExpected);
		}, Caller);

		await cache.Remove(Dto.Id);
		await events.Updated(this, tickets, entity.Id);
	}
}

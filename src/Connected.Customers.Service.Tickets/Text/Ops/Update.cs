using Connected.Customers.Service.Tickets.Text.Dtos;
using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Customers.Service.Tickets.Text.Ops;

internal sealed class Update(IStorageProvider storage, ITicketTextService text, IEventService events, ITicketTextCache cache)
  : ServiceAction<IUpdateTicketTextDto>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await text.Select(Dto)) as TicketText ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<TicketText>().Update(entity.Merge(Dto, State.Update), Dto, async () =>
		{
			await cache.Remove(Dto.Id);

			return await text.Select(Dto) as TicketText ?? throw new NullReferenceException(Strings.ErrEntityExpected);
		}, Caller);

		await cache.Remove(Dto.Id);
		await events.Updated(this, text, entity.Id);
	}
}

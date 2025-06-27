using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Customers.Service.Tickets.Text.Ops;

internal sealed class Delete(IStorageProvider storage, ITicketTextService text, IEventService events, ITicketTextCache cache)
  : ServiceAction<IPrimaryKeyDto<int>>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await text.Select(Dto)) as TicketText ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<TicketText>().Update(entity.Merge(Dto, State.Delete));
		await cache.Remove(Dto.Id);
		await events.Deleted(this, text, entity.Id);
	}
}

using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Customers.Service.Tickets.Text.Ops;

internal sealed class Delete(IStorageProvider storage, ITicketTextService text, IEventService events, ITicketTextCache cache)
  : ServiceAction<IDistributedPrimaryKeyDto<int, int>>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await text.Select(Dto)) as TicketText ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<TicketText>().Update(entity.Merge(Dto, State.Delete));
		await cache.Remove(Dto.DistributedKey());
		await events.Deleted(this, text, Dto.DistributedKey());
	}
}

using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Customers.Service.Desks.Ops;

internal sealed class Delete(IDeskService desks, IEventService events, IDeskCache cache, IStorageProvider storage)
	: ServiceAction<IPrimaryKeyDto<int>>
{
	protected override async Task OnInvoke()
	{
		_ = SetState(await desks.Select(Dto)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<Desk>().Update(Dto.AsEntity<Desk>(State.Delete));
		await cache.Remove(Dto.Id);
		await events.Deleted(this, desks, Dto.Id);
	}
}

using Connected.Customers.Desks;
using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Customers.Desks.Ops;

internal sealed class Update(IDeskService desks, IEventService events, IDeskCache cache, IStorageProvider storage, IUpdateDeskAmbient ambient)
	: ServiceAction<IPrimaryKeyDto<int>>
{
	protected override async Task OnInvoke()
	{
		_ = SetState(await desks.Select(Dto)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<Desk>().Update(Dto.AsEntity<Desk>(State.Update), Dto, async () =>
		{
			await cache.Refresh(Dto.Id);

			return SetState(await desks.Select(Dto)) as Desk ?? throw new NullReferenceException(Strings.ErrEntityExpected);
		}, Caller);

		await cache.Refresh(Dto.Id);
		await events.Updated(this, desks, Dto.Id);
	}
}

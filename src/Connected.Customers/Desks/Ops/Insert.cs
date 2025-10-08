using Connected.Customers.Desks;
using Connected.Customers.Desks.Dtos;
using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Customers.Desks.Ops;

internal sealed class Insert(IDeskService desks, IEventService events, IDeskCache cache, IStorageProvider storage, IInsertDeskAmbient ambient)
	: ServiceFunction<IInsertDeskDto, int>
{
	protected override async Task<int> OnInvoke()
	{
		var entity = await storage.Open<Desk>().Update(Dto.AsEntity<Desk>(State.Add, ambient)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await cache.Refresh(entity.Id);
		await events.Inserted(this, desks, entity.Id);

		return entity.Id;
	}
}

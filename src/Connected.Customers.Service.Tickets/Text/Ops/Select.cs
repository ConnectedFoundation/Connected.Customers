using Connected.Entities;
using Connected.Services;
using Connected.Storage;

namespace Connected.Customers.Service.Tickets.Text.Ops;

internal sealed class Select(IStorageProvider storage, ITicketTextCache cache)
  : ServiceFunction<IDistributedPrimaryKeyDto<int, int>, ITicketText?>
{
	protected override async Task<ITicketText?> OnInvoke()
	{
		return await cache.Get(Dto.DistributedKey(), async (f) =>
		{
			return await storage.Open<TicketText>().AsEntity(f => f.Head == Dto.Head && f.Id == Dto.Id);
		});
	}
}

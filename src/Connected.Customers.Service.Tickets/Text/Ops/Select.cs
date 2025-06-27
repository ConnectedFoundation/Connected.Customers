using Connected.Entities;
using Connected.Services;
using Connected.Storage;

namespace Connected.Customers.Service.Tickets.Text.Ops;

internal sealed class Select(IStorageProvider storage, ITicketTextCache cache)
  : ServiceFunction<IPrimaryKeyDto<int>, ITicketText?>
{
	protected override async Task<ITicketText?> OnInvoke()
	{
		return await cache.Get(Dto.Id, async (f) =>
		{
			return await storage.Open<TicketText>().AsEntity(f => f.Id == Dto.Id);
		});
	}
}

using Connected.Entities;
using Connected.Services;
using Connected.Storage;

namespace Connected.Customers.Service.Tickets.Ops;

internal sealed class Select(IStorageProvider storage, ITicketCache cache)
  : ServiceFunction<IPrimaryKeyDto<int>, ITicket?>
{
	protected override async Task<ITicket?> OnInvoke()
	{
		return await cache.Get(Dto.Id, async (f) =>
		{
			return await storage.Open<Ticket>().AsEntity(f => f.Id == Dto.Id);
		});
	}
}

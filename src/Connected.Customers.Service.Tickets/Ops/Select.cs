using Connected.Entities;
using Connected.Services;
using Connected.Storage;

namespace Connected.Customers.Service.Tickets.Ops;

internal sealed class Select(IStorageProvider storage, ITicketCache cache)
  : ServiceFunction<IDependentPrimaryKeyDto<int, int>, ITicket?>
{
	protected override async Task<ITicket?> OnInvoke()
	{
		return await cache.Get(Dto.GenerateKey(), async (f) =>
		{
			return await storage.Open<Ticket>().AsEntity(f =>
					f.Head == Dto.Head
				&& f.Id == Dto.Id);
		});
	}
}

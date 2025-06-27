using Connected.Entities;
using Connected.Services;
using Connected.Storage;

namespace Connected.Customers.Service.Tickets.Ops;

internal sealed class SelectByUrl(IStorageProvider storage, ITicketCache cache)
  : ServiceFunction<IValueDto<string>, ITicket?>
{
	protected override async Task<ITicket?> OnInvoke()
	{
		return await cache.Get(f => string.Equals(f.Url, Dto.Value, StringComparison.OrdinalIgnoreCase), async (f) =>
		{
			return await storage.Open<Ticket>().AsEntity(f => string.Equals(f.Url, Dto.Value, StringComparison.OrdinalIgnoreCase));
		});
	}
}

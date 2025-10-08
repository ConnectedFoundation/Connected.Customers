using Connected.Entities;
using Connected.Services;
using Connected.Storage;

namespace Connected.Customers.Tickets.Comments.Ops;

internal sealed class Select(IStorageProvider storage, ITicketCommentCache cache)
  : ServiceFunction<IPrimaryKeyDto<long>, ITicketComment?>
{
	protected override async Task<ITicketComment?> OnInvoke()
	{
		return await cache.Get(Dto.Id, async (f) =>
		{
			return await storage.Open<TicketComment>().AsEntity(f => f.Id == Dto.Id);
		});
	}
}

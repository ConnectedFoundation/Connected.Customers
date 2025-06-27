using Connected.Entities;
using Connected.Services;
using Connected.Storage;
using System.Collections.Immutable;

namespace Connected.Customers.Service.Tickets.Comments.Ops;

internal sealed class Query(IStorageProvider storage)
  : ServiceFunction<IHeadDto<int>, IImmutableList<ITicketComment>>
{
	protected override async Task<IImmutableList<ITicketComment>> OnInvoke()
	{
		return await storage.Open<TicketComment>().AsEntities<ITicketComment>(f => f.Document == Dto.Head);
	}
}

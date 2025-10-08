using Connected.Customers.Tickets;
using Connected.Entities;
using Connected.Services;
using Connected.Storage;
using System.Collections.Immutable;

namespace Connected.Customers.Tickets.Ops;

internal sealed class Query(IStorageProvider storage)
  : ServiceFunction<IHeadDto<int>, IImmutableList<ITicket>>
{
	protected override async Task<IImmutableList<ITicket>> OnInvoke()
	{
		return await storage.Open<Ticket>().AsEntities<ITicket>(f => f.Head == Dto.Head);
	}
}

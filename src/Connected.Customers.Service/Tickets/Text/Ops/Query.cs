using Connected.Entities;
using Connected.Services;
using Connected.Storage;
using System.Collections.Immutable;

namespace Connected.Customers.Service.Tickets.Text.Ops;

internal sealed class Query(IStorageProvider storage)
  : ServiceFunction<IDistributedPrimaryKeyListDto<int, int>, IImmutableList<ITicketText>>
{
	protected override async Task<IImmutableList<ITicketText>> OnInvoke()
	{
		return await storage.Open<TicketText>().AsEntities<ITicketText>(f => Dto.Items.Any(g => g.Item1 == f.Head && g.Item2 == f.Id));
	}
}

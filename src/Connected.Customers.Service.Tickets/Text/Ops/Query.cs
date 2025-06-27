using Connected.Entities;
using Connected.Services;
using Connected.Storage;
using System.Collections.Immutable;

namespace Connected.Customers.Service.Tickets.Text.Ops;

internal sealed class Query(IStorageProvider storage)
  : ServiceFunction<IPrimaryKeyListDto<int>, IImmutableList<ITicketText>>
{
	protected override async Task<IImmutableList<ITicketText>> OnInvoke()
	{
		return await storage.Open<TicketText>().AsEntities<ITicketText>(f => Dto.Items.Any(g => g == f.Id));
	}
}

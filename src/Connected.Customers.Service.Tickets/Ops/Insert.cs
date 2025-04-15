using Connected.Customers.Service.Tickets.Dtos;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Customers.Service.Tickets.Ops;

internal sealed class Insert(IStorageProvider storage, ITicketService tickets, IEventService events)
  : ServiceFunction<IInsertTicketDto, int>
{
	protected override async Task<int> OnInvoke()
	{
		var result = await storage.Open<Ticket>().Update(Dto.AsEntity<Ticket>(Entities.State.Add)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await events.Inserted(this, tickets, result.Id);

		return result.Id;
	}
}

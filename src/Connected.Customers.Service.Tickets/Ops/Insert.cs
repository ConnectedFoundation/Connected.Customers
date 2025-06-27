using Connected.Customers.Service.Tickets.Dtos;
using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Customers.Service.Tickets.Ops;

internal sealed class Insert(IStorageProvider storage, ITicketService tickets, IEventService events)
  : ServiceFunction<IInsertTicketDto, int>
{
	protected override async Task<int> OnInvoke()
	{
		var entity = await storage.Open<Ticket>().Update(Dto.AsEntity<Ticket>(State.Add)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		SetState(entity);

		await events.Inserted(this, tickets, entity.GenerateKey());

		return entity.Id;
	}
}

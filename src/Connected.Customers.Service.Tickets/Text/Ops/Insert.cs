using Connected.Customers.Service.Tickets.Text.Dtos;
using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Customers.Service.Tickets.Text.Ops;

internal sealed class Insert(IStorageProvider storage, ITicketTextService text, IEventService events)
  : ServiceFunction<IInsertTicketTextDto, int>
{
	protected override async Task<int> OnInvoke()
	{
		var result = await storage.Open<TicketText>().Update(Dto.AsEntity<TicketText>(State.Add)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		SetState(result);

		await events.Inserted(this, text, result.Id);

		return result.Id;
	}
}

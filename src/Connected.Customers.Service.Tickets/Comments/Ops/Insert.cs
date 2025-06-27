using Connected.Customers.Service.Tickets.Comments.Dtos;
using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Customers.Service.Tickets.Comments.Ops;

internal sealed class Insert(IStorageProvider storage, ITicketCommentService comments, IEventService events)
  : ServiceFunction<IInsertTicketCommentDto, long>
{
	protected override async Task<long> OnInvoke()
	{
		var result = await storage.Open<TicketComment>().Update(Dto.AsEntity<TicketComment>(State.Add)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		SetState(result);

		await events.Inserted(this, comments, result.Id);

		return result.Id;
	}
}

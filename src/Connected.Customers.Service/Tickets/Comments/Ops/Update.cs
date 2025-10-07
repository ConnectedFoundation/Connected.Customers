using Connected.Customers.Service.Tickets.Comments.Dtos;
using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Customers.Service.Tickets.Comments.Ops;

internal sealed class Update(IStorageProvider storage, ITicketCommentService comments, IEventService events, ITicketCommentCache cache)
  : ServiceAction<IUpdateTicketCommentDto>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await comments.Select(Dto)) as TicketComment ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<TicketComment>().Update(entity.Merge(Dto, State.Update), Dto, async () =>
		{
			await cache.Remove(Dto.Id);

			return await comments.Select(Dto) as TicketComment ?? throw new NullReferenceException(Strings.ErrEntityExpected);
		}, Caller);

		await cache.Remove(Dto.Id);
		await events.Updated(this, comments, entity.Id);
	}
}

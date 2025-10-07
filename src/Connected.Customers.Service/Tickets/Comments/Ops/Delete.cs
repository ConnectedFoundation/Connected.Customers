using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Customers.Service.Tickets.Comments.Ops;

internal sealed class Delete(IStorageProvider storage, ITicketCommentService comments, IEventService events, ITicketCommentCache cache)
  : ServiceAction<IPrimaryKeyDto<long>>
{
	protected override async Task OnInvoke()
	{
		var entity = SetState(await comments.Select(Dto)) as TicketComment ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await storage.Open<TicketComment>().Update(entity.Merge(Dto, State.Delete));
		await cache.Remove(Dto.Id);
		await events.Deleted(this, comments, entity.Id);
	}
}

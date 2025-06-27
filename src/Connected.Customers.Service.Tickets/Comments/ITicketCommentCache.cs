using Connected.Caching;

namespace Connected.Customers.Service.Tickets.Comments;

internal interface ITicketCommentCache
	: ICacheContainer<TicketComment, long>
{
}

using Connected.Caching;

namespace Connected.Customers.Tickets.Comments;

internal interface ITicketCommentCache
	: ICacheContainer<TicketComment, long>
{
}

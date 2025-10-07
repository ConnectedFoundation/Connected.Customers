using Connected.Caching;

namespace Connected.Customers.Service.Tickets.Comments;

internal sealed class TicketCommentCache(ICachingService cachingService)
		: CacheContainer<TicketComment, long>(cachingService, ServiceMetaData.TicketCommentKey), ITicketCommentCache
{
}

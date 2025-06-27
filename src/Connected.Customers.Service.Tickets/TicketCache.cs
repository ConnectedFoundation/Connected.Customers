using Connected.Caching;

namespace Connected.Customers.Service.Tickets;

internal sealed class TicketCache(ICachingService cachingService)
		: CacheContainer<Ticket, int>(cachingService, ServiceMetaData.TicketKey), ITicketCache
{
}

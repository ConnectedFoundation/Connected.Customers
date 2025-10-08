using Connected.Caching;

namespace Connected.Customers.Tickets.Text;

internal sealed class TicketTextCache(ICachingService cachingService)
		: CacheContainer<TicketText, string>(cachingService, ServiceMetaData.TicketTextKey), ITicketTextCache
{
}

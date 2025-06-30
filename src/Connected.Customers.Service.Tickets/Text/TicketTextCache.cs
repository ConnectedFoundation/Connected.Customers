using Connected.Caching;

namespace Connected.Customers.Service.Tickets.Text;

internal sealed class TicketTextCache(ICachingService cachingService)
		: CacheContainer<TicketText, string>(cachingService, ServiceMetaData.TicketTextKey), ITicketTextCache
{
}

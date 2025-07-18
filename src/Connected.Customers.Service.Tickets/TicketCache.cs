﻿using Connected.Caching;

namespace Connected.Customers.Service.Tickets;

internal sealed class TicketCache(ICachingService cachingService)
		: CacheContainer<Ticket, string>(cachingService, ServiceMetaData.TicketKey), ITicketCache
{
}

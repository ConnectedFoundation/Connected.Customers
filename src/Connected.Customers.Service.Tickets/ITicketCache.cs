using Connected.Caching;

namespace Connected.Customers.Service.Tickets;

internal interface ITicketCache
	: ICacheContainer<Ticket, int>
{
}

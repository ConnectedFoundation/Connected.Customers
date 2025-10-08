using Connected.Caching;

namespace Connected.Customers.Tickets;

internal interface ITicketCache
	: ICacheContainer<Ticket, string>
{
}

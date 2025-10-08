using Connected.Caching;

namespace Connected.Customers.Tickets.Text;

internal interface ITicketTextCache
	: ICacheContainer<TicketText, string>
{
}

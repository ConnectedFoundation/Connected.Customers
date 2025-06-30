using Connected.Caching;

namespace Connected.Customers.Service.Tickets.Text;

internal interface ITicketTextCache
	: ICacheContainer<TicketText, string>
{
}

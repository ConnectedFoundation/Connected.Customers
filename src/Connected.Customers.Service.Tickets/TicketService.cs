using Connected.Customers.Service.Tickets.Dtos;

namespace Connected.Customers.Service.Tickets;

internal sealed class TicketService(IServiceProvider services) : Services.Service(services), ITicketService
{
	public Task<int> Insert(IInsertTicketDto dto)
	{
		throw new NotImplementedException();
	}
}

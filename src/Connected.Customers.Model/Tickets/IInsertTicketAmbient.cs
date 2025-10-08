using Connected.Customers.Tickets.Dtos;
using Connected.Services;

namespace Connected.Customers.Tickets;

public interface IInsertTicketAmbient : IAmbientProvider<IInsertTicketDto>
{
	string? Url { get; set; }
}

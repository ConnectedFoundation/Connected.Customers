using Connected.Customers.Service.Tickets.Dtos;
using Connected.Services;

namespace Connected.Customers.Service.Tickets;

public interface IInsertTicketAmbient : IAmbientProvider<IInsertTicketDto>
{
	string? Url { get; set; }
}

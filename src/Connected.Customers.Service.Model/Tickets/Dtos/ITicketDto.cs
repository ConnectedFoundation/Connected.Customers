using Connected.Documents.Dtos;

namespace Connected.Customers.Service.Tickets.Dtos;

public interface ITicketDto : IDocumentDto
{
	TicketStatus Status { get; set; }
}

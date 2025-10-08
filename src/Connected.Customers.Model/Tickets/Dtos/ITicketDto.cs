using Connected.Customers.Tickets;
using Connected.Documents.Dtos;

namespace Connected.Customers.Tickets.Dtos;

public interface ITicketDto : IDocumentDto
{
	int Head { get; set; }
	TicketStage Stage { get; set; }
}

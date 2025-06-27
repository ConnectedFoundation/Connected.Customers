using Connected.Documents.Dtos;

namespace Connected.Customers.Service.Tickets.Dtos;

public interface ITicketDto : IDocumentDto
{
	int Head { get; set; }
	TicketStatus Status { get; set; }
}

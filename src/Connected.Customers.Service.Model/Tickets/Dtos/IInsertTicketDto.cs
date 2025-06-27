using Connected.Documents.Dtos;

namespace Connected.Customers.Service.Tickets.Dtos;

public interface IInsertTicketDto : IInsertDocumentDto, ITicketDto
{
	int Desk { get; set; }
}

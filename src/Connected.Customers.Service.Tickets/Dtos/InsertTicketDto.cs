using Connected.Documents.Dtos;

namespace Connected.Customers.Service.Tickets.Dtos;

internal sealed class InsertTicketDto : InsertDocumentDto, IInsertTicketDto
{
	public TicketStatus Status { get; set; } = TicketStatus.Triage;
}

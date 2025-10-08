using Connected.Annotations;
using Connected.Customers.Tickets;
using Connected.Documents.Dtos;

namespace Connected.Customers.Tickets.Dtos;

internal sealed class InsertTicketDto : InsertDocumentDto, IInsertTicketDto
{
	public TicketStage Stage { get; set; } = TicketStage.Triage;

	[MinValue(1)]
	public int Head { get; set; }
}

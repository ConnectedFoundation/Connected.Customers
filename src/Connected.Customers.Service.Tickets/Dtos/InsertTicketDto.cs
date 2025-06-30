using Connected.Annotations;
using Connected.Documents.Dtos;

namespace Connected.Customers.Service.Tickets.Dtos;

internal sealed class InsertTicketDto : InsertDocumentDto, IInsertTicketDto
{
	public TicketStage Stage { get; set; } = TicketStage.Triage;

	[MinValue(1)]
	public int Head { get; set; }
}

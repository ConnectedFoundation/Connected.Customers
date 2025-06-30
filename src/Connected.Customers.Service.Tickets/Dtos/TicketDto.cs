using Connected.Annotations;
using Connected.Documents.Dtos;

namespace Connected.Customers.Service.Tickets.Dtos;

internal abstract class TicketDto : DocumentDto, ITicketDto
{
	public TicketStage Stage { get; set; } = TicketStage.Triage;

	[MinValue(1)]
	public int Head { get; set; }
}

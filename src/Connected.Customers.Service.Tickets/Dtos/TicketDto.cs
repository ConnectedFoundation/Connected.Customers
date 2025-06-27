using Connected.Annotations;
using Connected.Documents.Dtos;

namespace Connected.Customers.Service.Tickets.Dtos;

internal abstract class TicketDto : DocumentDto, ITicketDto
{
	public TicketStatus Status { get; set; } = TicketStatus.Triage;

	[MinValue(1)]
	public int Head { get; set; }
}

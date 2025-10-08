using Connected.Annotations;
using Connected.Documents.Text.Dtos;

namespace Connected.Customers.Tickets.Text.Dtos;

internal sealed class TicketTextDto : DocumentTextDto<int>, ITicketTextDto
{
	[MinValue(1)]
	public int Head { get; set; }
}

using Connected.Annotations;

namespace Connected.Customers.Service.Tickets.Dtos;

internal sealed class UpdateTicketDto : TicketDto, IUpdateTicketDto
{
	[MinValue(1)]
	public int Id { get; set; }
}

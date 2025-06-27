using Connected.Annotations;

namespace Connected.Customers.Service.Tickets.Dtos;

internal sealed class UpdateTicketDto : TicketDto, IUpdateTicketDto
{
	[MinValue(1)]
	public int Id { get; set; }

	public DateTimeOffset? Modified { get; set; }
	public int? Owner { get; set; }

	[MinValue(0)]
	public int FileCount { get; set; }
}

using Connected.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Connected.Customers.Tickets.Dtos;

internal sealed class UpdateTicketDto : TicketDto, IUpdateTicketDto
{
	[MinValue(1)]
	public int Id { get; set; }

	public DateTimeOffset? Modified { get; set; }

	[MaxLength(256)]
	public string? Owner { get; set; }

	[MinValue(0)]
	public int FileCount { get; set; }
}

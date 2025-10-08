using Connected.Annotations;
using Connected.Services;
using System.ComponentModel.DataAnnotations;

namespace Connected.Customers.Tickets.Dtos;

internal sealed class SelectTicketByUrlDto : Dto, ISelectTicketByUrlDto
{
	[MinValue(1)]
	public int Head { get; set; }

	[Required, MaxLength(136)]
	public required string Url { get; set; }
}

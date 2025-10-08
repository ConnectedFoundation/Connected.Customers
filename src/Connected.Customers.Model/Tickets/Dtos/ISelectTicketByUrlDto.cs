using Connected.Services;

namespace Connected.Customers.Tickets.Dtos;

public interface ISelectTicketByUrlDto : IDto
{
	int Head { get; set; }
	string Url { get; set; }
}

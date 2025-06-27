using Connected.Services;

namespace Connected.Customers.Service.Tickets.Dtos;

public interface ISelectTicketByUrlDto : IDto
{
	int Head { get; set; }
	string Url { get; set; }
}

using Connected.Documents.Text.Dtos;

namespace Connected.Customers.Tickets.Text.Dtos;

public interface ITicketTextDto : IDocumentTextDto<int>
{
	int Head { get; set; }
}

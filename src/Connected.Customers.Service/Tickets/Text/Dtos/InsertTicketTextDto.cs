using Connected.Annotations;
using Connected.Documents.Text.Dtos;

namespace Connected.Customers.Service.Tickets.Text.Dtos;

internal sealed class InsertTicketTextDto : InsertDocumentTextDto<int>, IInsertTicketTextDto
{
	[MinValue(1)]
	public int Head { get; set; }
}

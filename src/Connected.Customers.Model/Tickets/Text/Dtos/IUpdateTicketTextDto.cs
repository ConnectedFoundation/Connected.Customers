using Connected.Documents.Text.Dtos;
using Connected.Services;

namespace Connected.Customers.Tickets.Text.Dtos;

public interface IUpdateTicketTextDto : IUpdateDocumentTextDto<int>, IDistributedPrimaryKeyDto<int, int>
{
}

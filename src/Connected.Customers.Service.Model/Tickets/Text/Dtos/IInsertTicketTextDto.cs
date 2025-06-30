using Connected.Documents.Text.Dtos;
using Connected.Services;

namespace Connected.Customers.Service.Tickets.Text.Dtos;

public interface IInsertTicketTextDto : IInsertDocumentTextDto<int>, IDistributedPrimaryKeyDto<int, int>
{

}

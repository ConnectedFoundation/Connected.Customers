using Connected.Documents.Dtos;
using Connected.Services;

namespace Connected.Customers.Service.Tickets.Dtos;

public interface IUpdateTicketDto : IUpdateDocumentDto<int>, ITicketDto, IDistributedPrimaryKeyDto<int, int>
{
}

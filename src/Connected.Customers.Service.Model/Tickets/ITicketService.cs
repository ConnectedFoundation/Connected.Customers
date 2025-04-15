using Connected.Annotations;
using Connected.Customers.Service.Tickets.Dtos;

namespace Connected.Customers.Service.Tickets;

[Service, ServiceUrl(ServiceUrls.Tickets)]
public interface ITicketService
{
	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task<int> Insert(IInsertTicketDto dto);
}

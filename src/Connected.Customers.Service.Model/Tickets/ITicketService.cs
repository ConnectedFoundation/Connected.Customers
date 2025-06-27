using Connected.Annotations;
using Connected.Customers.Service.Tickets.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Customers.Service.Tickets;

[Service, ServiceUrl(ServiceUrls.Tickets)]
public interface ITicketService
{
	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task<int> Insert(IInsertTicketDto dto);

	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task Update(IUpdateTicketDto dto);

	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IImmutableList<ITicket>> Query(IHeadDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<ITicket?> Select(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get), ServiceUrl(ServiceUrls.SelectByUrlOperation)]
	Task<ITicket?> Select(IValueDto<string> dto);
}

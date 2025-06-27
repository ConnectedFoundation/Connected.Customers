using Connected.Annotations;
using Connected.Customers.Service.Tickets.Text.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Customers.Service.Tickets.Text;

[Service, ServiceUrl(ServiceUrls.TicketTexts)]
public interface ITicketTextService
{

	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task<int> Insert(IInsertTicketTextDto dto);

	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task Update(IUpdateTicketTextDto dto);

	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IImmutableList<ITicketText>> Query(IPrimaryKeyListDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<ITicketText?> Select(IPrimaryKeyDto<int> dto);
}

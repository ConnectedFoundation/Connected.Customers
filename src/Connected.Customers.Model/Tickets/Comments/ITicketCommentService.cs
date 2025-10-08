using Connected.Annotations;
using Connected.Customers.Tickets.Comments.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Customers.Tickets.Comments;

[Service, ServiceUrl(ServiceUrls.TicketComments)]
public interface ITicketCommentService
{
	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task<long> Insert(IInsertTicketCommentDto dto);

	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task Update(IUpdateTicketCommentDto dto);

	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<long> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IImmutableList<ITicketComment>> Query(IHeadDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<ITicketComment?> Select(IPrimaryKeyDto<long> dto);
}

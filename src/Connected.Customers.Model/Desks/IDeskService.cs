using Connected.Annotations;
using Connected.Customers.Desks.Dtos;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Customers.Desks;

[Service, ServiceUrl(ServiceUrls.Desks)]
public interface IDeskService
{
	[ServiceOperation(ServiceOperationVerbs.Put)]
	Task<int> Insert(IInsertDeskDto dto);

	[ServiceOperation(ServiceOperationVerbs.Post)]
	Task Update(IUpdateDeskDto dto);

	[ServiceOperation(ServiceOperationVerbs.Delete)]
	Task Delete(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IDesk?> Select(IPrimaryKeyDto<int> dto);

	[ServiceOperation(ServiceOperationVerbs.Get)]
	Task<IImmutableList<IDesk>> Query(IQueryDto? dto);
}

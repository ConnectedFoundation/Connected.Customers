using Connected.Entities;
using Connected.Services;

namespace Connected.Customers.Service.Desks.Ops;

internal sealed class Select(IDeskCache cache)
	: ServiceFunction<IPrimaryKeyDto<int>, IDesk?>
{
	protected override async Task<IDesk?> OnInvoke()
	{
		return await cache.AsEntity<IDesk>(f => f.Id == Dto.Id);
	}
}

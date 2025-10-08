using Connected.Customers.Desks;
using Connected.Entities;
using Connected.Services;

namespace Connected.Customers.Desks.Ops;

internal sealed class Select(IDeskCache cache)
	: ServiceFunction<IPrimaryKeyDto<int>, IDesk?>
{
	protected override async Task<IDesk?> OnInvoke()
	{
		return await cache.AsEntity(f => f.Id == Dto.Id);
	}
}

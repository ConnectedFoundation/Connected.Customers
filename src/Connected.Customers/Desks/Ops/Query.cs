using Connected.Entities;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Customers.Desks.Ops;

internal sealed class Query(IDeskCache cache)
	: ServiceFunction<IQueryDto, IImmutableList<IDesk>>
{
	protected override async Task<IImmutableList<IDesk>> OnInvoke()
	{
		return await cache.WithDto(Dto).AsEntities();
	}
}

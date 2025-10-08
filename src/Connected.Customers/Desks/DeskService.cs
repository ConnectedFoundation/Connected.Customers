using Connected.Customers.Desks.Dtos;
using Connected.Customers.Desks.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Customers.Desks;

internal sealed class DeskService(IServiceProvider services) : Service(services), IDeskService
{
	public async Task Delete(IPrimaryKeyDto<int> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public async Task<int> Insert(IInsertDeskDto dto)
	{
		return await Invoke(GetOperation<Insert>(), dto);
	}

	public async Task<IImmutableList<IDesk>> Query(IQueryDto? dto)
	{
		return await Invoke(GetOperation<Query>(), dto ?? QueryDto.NoPaging);
	}

	public async Task<IDesk?> Select(IPrimaryKeyDto<int> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}

	public async Task Update(IUpdateDeskDto dto)
	{
		await Invoke(GetOperation<Update>(), dto);
	}
}

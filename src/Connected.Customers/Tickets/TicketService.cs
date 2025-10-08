using Connected.Customers.Tickets.Dtos;
using Connected.Customers.Tickets.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Customers.Tickets;

internal sealed class TicketService(IServiceProvider services)
	: Service(services), ITicketService
{
	public async Task Delete(IDistributedPrimaryKeyDto<int, int> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public async Task<int> Insert(IInsertTicketDto dto)
	{
		return await Invoke(GetOperation<Insert>(), dto);
	}

	public async Task Patch(IDistributedPatchDto<int, int> dto)
	{
		await Invoke(GetOperation<Patch>(), dto);
	}

	public async Task<IImmutableList<ITicket>> Query(IHeadDto<int> dto)
	{
		return await Invoke(GetOperation<Query>(), dto);
	}

	public async Task<ITicket?> Select(IDistributedPrimaryKeyDto<int, int> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}

	public async Task<ITicket?> Select(ISelectTicketByUrlDto dto)
	{
		return await Invoke(GetOperation<SelectByUrl>(), dto);
	}

	public async Task Update(IUpdateTicketDto dto)
	{
		await Invoke(GetOperation<Update>(), dto);
	}
}

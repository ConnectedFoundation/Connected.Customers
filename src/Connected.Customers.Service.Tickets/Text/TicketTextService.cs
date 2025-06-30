using Connected.Customers.Service.Tickets.Text.Dtos;
using Connected.Customers.Service.Tickets.Text.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Customers.Service.Tickets.Text;

internal sealed class TicketTextService(IServiceProvider services)
	: Services.Service(services), ITicketTextService
{
	public async Task Delete(IDistributedPrimaryKeyDto<int, int> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public async Task<int> Insert(IInsertTicketTextDto dto)
	{
		return await Invoke(GetOperation<Insert>(), dto);
	}

	public async Task<IImmutableList<ITicketText>> Query(IDistributedPrimaryKeyListDto<int, int> dto)
	{
		return await Invoke(GetOperation<Query>(), dto);
	}

	public async Task<ITicketText?> Select(IDistributedPrimaryKeyDto<int, int> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}

	public async Task Update(IUpdateTicketTextDto dto)
	{
		await Invoke(GetOperation<Update>(), dto);
	}
}

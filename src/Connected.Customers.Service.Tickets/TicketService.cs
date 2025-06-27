using Connected.Customers.Service.Tickets.Dtos;
using Connected.Customers.Service.Tickets.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Customers.Service.Tickets;

internal sealed class TicketService(IServiceProvider services)
	: Services.Service(services), ITicketService
{
	public async Task Delete(IPrimaryKeyDto<int> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public async Task<int> Insert(IInsertTicketDto dto)
	{
		return await Invoke(GetOperation<Insert>(), dto);
	}

	public async Task<IImmutableList<ITicket>> Query(IHeadDto<int> dto)
	{
		return await Invoke(GetOperation<Query>(), dto);
	}

	public async Task<ITicket?> Select(IPrimaryKeyDto<int> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}

	public async Task<ITicket?> Select(IValueDto<string> dto)
	{
		return await Invoke(GetOperation<SelectByUrl>(), dto);
	}

	public async Task Update(IUpdateTicketDto dto)
	{
		await Invoke(GetOperation<Update>(), dto);
	}
}

using Connected.Customers.Tickets.Comments.Dtos;
using Connected.Customers.Tickets.Comments.Ops;
using Connected.Services;
using System.Collections.Immutable;

namespace Connected.Customers.Tickets.Comments;

internal sealed class TicketCommentService(IServiceProvider services)
	: Service(services), ITicketCommentService
{
	public async Task Delete(IPrimaryKeyDto<long> dto)
	{
		await Invoke(GetOperation<Delete>(), dto);
	}

	public async Task<long> Insert(IInsertTicketCommentDto dto)
	{
		return await Invoke(GetOperation<Insert>(), dto);
	}

	public async Task<IImmutableList<ITicketComment>> Query(IHeadDto<int> dto)
	{
		return await Invoke(GetOperation<Query>(), dto);
	}

	public async Task<ITicketComment?> Select(IPrimaryKeyDto<long> dto)
	{
		return await Invoke(GetOperation<Select>(), dto);
	}

	public async Task Update(IUpdateTicketCommentDto dto)
	{
		await Invoke(GetOperation<Update>(), dto);
	}
}

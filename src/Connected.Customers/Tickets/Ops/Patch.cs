using Connected.Customers.Tickets;
using Connected.Customers.Tickets.Dtos;
using Connected.Services;

namespace Connected.Customers.Tickets.Ops;

internal sealed class Patch(ITicketService tickets)
  : ServiceAction<IDistributedPatchDto<int, int>>
{
	protected override async Task OnInvoke()
	{
		var entity = await tickets.Select(Dto) as Ticket ?? throw new NullReferenceException(Strings.ErrEntityExpected);

		await tickets.Update(Dto.Patch<IUpdateTicketDto, ITicket>(entity));
	}
}

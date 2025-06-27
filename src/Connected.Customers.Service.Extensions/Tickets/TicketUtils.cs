using Connected.Customers.Service.Desks;
using Connected.Services;

namespace Connected.Customers.Service.Tickets;

public static class TicketUtils
{
	public static async Task<IDesk?> ResolveDesk(this IDeskService desks, string? directoryName)
	{
		if (directoryName is null)
			return null;

		var parser = new TicketPathParser();

		parser.Parse(directoryName);

		if (parser.Desk is null)
			return null;

		return await desks.Select(Dto.Factory.CreatePrimaryKey(parser.Desk.GetValueOrDefault()));
	}

	public static async Task<ITicket?> ResolveTicket(this ITicketService tickets, string? directoryName)
	{
		if (directoryName is null)
			return null;

		var parser = new TicketPathParser();

		parser.Parse(directoryName);

		if (parser.Desk is null || parser.Ticket is null)
			return null;

		return await tickets.Select(Dto.Factory.CreateDependentPrimaryKey(parser.Desk.GetValueOrDefault(), parser.Ticket.GetValueOrDefault()));
	}
}

using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Documents;

namespace Connected.Customers.Service.Tickets;

[Table(Schema = SchemaAttribute.CustomersSchema)]
internal sealed record Ticket : Document<int>, ITicket
{
	[Ordinal(0)]
	public int Desk { get; init; }

	[Ordinal(1)]
	public TicketStatus Status { get; init; }
}

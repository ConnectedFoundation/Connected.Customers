using Connected.Documents;
using Connected.Entities;

namespace Connected.Customers.Service.Tickets;

public enum TicketStatus
{
	Triage = 1,
	Active = 2,
	Complete = 3,
	Archive = 4
}

public interface ITicket : IDocument<int>, IDependentEntity<int, int>
{
	TicketStatus Status { get; init; }
}

using Connected.Documents;

namespace Connected.Customers.Service.Tickets;

public enum TicketStatus
{
	Triage = 1,
	Active = 2,
	Complete = 3,
	Archive = 4
}

public interface ITicket : IDocument<int>
{
	TicketStatus Status { get; init; }
}

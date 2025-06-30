using Connected.Documents;
using Connected.Entities;

namespace Connected.Customers.Service.Tickets;

public enum TicketStage
{
	Triage = 1,
	Active = 2,
	Complete = 3,
	Archive = 4
}

public interface ITicket : IDocument<int>, IDistributedEntity<int, int>
{
	TicketStage Stage { get; init; }
}

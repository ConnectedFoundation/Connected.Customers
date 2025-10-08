using Connected.Annotations.Entities;
using Connected.Customers.Desks;
using Connected.Customers.Tickets;
using Connected.Customers.Tickets.Comments;
using Connected.Customers.Tickets.Text;

namespace Connected.Customers;

public static class ServiceMetaData
{
	public const string DeskKey = $"{SchemaAttribute.CustomersSchema}.{nameof(IDesk)}";
	public const string TicketKey = $"{SchemaAttribute.CustomersSchema}.{nameof(ITicket)}";
	public const string TicketTextKey = $"{SchemaAttribute.CustomersSchema}.{nameof(ITicketText)}";
	public const string TicketCommentKey = $"{SchemaAttribute.CustomersSchema}.{nameof(ITicketComment)}";

	public const string TicketFilesRootDirectory = "customers/service/tickets";
}

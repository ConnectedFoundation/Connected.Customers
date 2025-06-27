using Connected.Annotations.Entities;
using Connected.Customers.Service.Desks;
using Connected.Customers.Service.Tickets;
using Connected.Customers.Service.Tickets.Text;

namespace Connected.Customers.Service;

public static class ServiceMetaData
{
	public const string DeskKey = $"{SchemaAttribute.CustomersSchema}.{nameof(IDesk)}";
	public const string TicketKey = $"{SchemaAttribute.CustomersSchema}.{nameof(ITicket)}";
	public const string TicketTextKey = $"{SchemaAttribute.CustomersSchema}.{nameof(ITicketText)}";
}

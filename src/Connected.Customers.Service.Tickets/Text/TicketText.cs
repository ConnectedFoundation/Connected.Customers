using Connected.Annotations.Entities;
using Connected.Documents.Text;

namespace Connected.Customers.Service.Tickets.Text;

[Table(Schema = SchemaAttribute.CustomersSchema)]
internal sealed record TicketText : DocumentText<int>, ITicketText
{
}

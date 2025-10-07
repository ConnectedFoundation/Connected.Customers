using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Documents.Text;

namespace Connected.Customers.Service.Tickets.Text;

[Table(Schema = SchemaAttribute.CustomersSchema)]
internal sealed record TicketText : DocumentText<int>, ITicketText
{
	[Ordinal(0), Index(false)]
	public int Head { get; init; }
}

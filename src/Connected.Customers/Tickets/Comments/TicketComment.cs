using Connected.Annotations.Entities;
using Connected.Documents.Comments;

namespace Connected.Customers.Tickets.Comments;

[Table(Schema = SchemaAttribute.CustomersSchema)]
internal sealed record TicketComment : DocumentComment<int>, ITicketComment
{
}

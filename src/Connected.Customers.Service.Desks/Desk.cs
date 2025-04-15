using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities;

namespace Connected.Customers.Service.Desks;

[Table(Schema = SchemaAttribute.CustomersSchema)]
internal sealed record Desk : ConsistentEntity<int>, IDesk
{
	[Ordinal(0), Length(128)]
	public required string Name { get; init; }

	[Ordinal(1), Length(136)]
	public required string Url { get; init; }

	[Ordinal(1)]
	public Status Status { get; init; }
}

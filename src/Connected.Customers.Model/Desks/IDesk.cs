using Connected.Entities;

namespace Connected.Customers.Desks;

public interface IDesk : IEntity<int>
{
	string Name { get; init; }
	string Url { get; init; }
	Status Status { get; init; }
}
